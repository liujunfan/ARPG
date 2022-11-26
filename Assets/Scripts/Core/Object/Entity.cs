using System;
using System.Collections.Generic;

namespace Nono
{
    [System.Flags]
    public enum EntityStatus: byte
    {
        None = 0,
        IsFromPool = 1,
        IsRegister = 1 << 1,
        IsComponent = 1 << 2,
        IsCreated = 1 << 3,
        IsNew = 1 << 4,
    }

    public class Entity : IDisposable
    {
        protected Entity()
        {
        }
#if ENABLE_VIEW
        private UnityEngine.GameObject view;
#endif
        private EntityStatus status = EntityStatus.None;
        private Dictionary<long, Entity> children;
        private Dictionary<Type, Entity> components;
        protected virtual string ViewName => GetType().Name;
        protected Entity parent;
        protected Entity domain;

        private bool IsFromPool
        {
            get => (status & EntityStatus.IsFromPool) == EntityStatus.IsFromPool;
            set
            {
                if (value)
                    status |= EntityStatus.IsFromPool;
                else
                    status &= ~EntityStatus.IsFromPool;
            }
        }

        protected bool IsRegister
        {
            get => (status & EntityStatus.IsRegister) == EntityStatus.IsRegister;
            set
            {
                if (IsRegister == value)
                {
                    return;
                }

                if (value)
                {
                    status |= EntityStatus.IsRegister;
                }
                else
                {
                    status &= ~EntityStatus.IsRegister;
                }

#if ENABLE_VIEW
                if (value)
                {
                    view = new UnityEngine.GameObject(ViewName);
                    //view.AddComponent<ComponentView>().Component = this;
                    view.transform.SetParent(Parent == null
                        ? UnityEngine.GameObject.Find("Global").transform
                        : Parent.view.transform);
                }
                else
                {
                    UnityEngine.Object.Destroy(view);
                }
#endif
            }
        }

        private bool IsComponent
        {
            get => (status & EntityStatus.IsComponent) == EntityStatus.IsComponent;
            set
            {
                if (value)
                {
                    status |= EntityStatus.IsComponent;
                }
                else
                {
                    status &= ~EntityStatus.IsComponent;
                }
            }
        }

        protected bool IsCreated
        {
            get => (status & EntityStatus.IsCreated) == EntityStatus.IsCreated;
            set
            {
                if (value)
                {
                    status |= EntityStatus.IsCreated;
                }
                else
                {
                    status &= ~EntityStatus.IsCreated;
                }
            }
        }

        protected bool IsNew
        {
            get => (status & EntityStatus.IsNew) == EntityStatus.IsNew;
            set
            {
                if (value)
                {
                    status |= EntityStatus.IsNew;
                }
                else
                {
                    status &= ~EntityStatus.IsNew;
                }
            }
        }

        private Entity ComponentParent
        {
            set
            {
                if (value == null)
                {
                    throw new Exception($"cant set parent null: {GetType().Name}");
                }

                if (value == this)
                {
                    throw new Exception($"cant set parent self: {GetType().Name}");
                }

                // 严格限制parent必须要有domain,也就是说parent必须在数据树上面
                if (value.Domain == null)
                {
                    throw new Exception(
                        $"cant set parent because parent domain is null: {GetType().Name} {value.GetType().Name}");
                }

                if (parent != null) // 之前有parent
                {
                    // parent相同，不设置
                    if (parent == value)
                    {
                        //Log.Error($"重复设置了Parent: {GetType().Name} parent: {parent.GetType().Name}");
                        return;
                    }

                    parent.RemoveFromComponents(this);
                }

                parent = value;
                IsComponent = true;
                parent.AddComponent(this);
                Domain = parent.domain;
            }
        }

        public Entity Parent
        {
            get => parent;
            private set
            {
                if (value == null)
                {
                    throw new Exception($"cant set parent null: {GetType().Name}");
                }

                if (value == this)
                {
                    throw new Exception($"cant set parent self: {GetType().Name}");
                }

                // 严格限制parent必须要有domain,也就是说parent必须在数据树上面
                if (value.Domain == null)
                {
                    throw new Exception(
                        $"cant set parent because parent domain is null: {GetType().Name} {value.GetType().Name}");
                }

                if (parent != null) // 之前有parent
                {
                    // parent相同，不设置
                    if (parent == value)
                    {
                        //Log.Error($"重复设置了Parent: {GetType().Name} parent: {parent.GetType().Name}");
                        return;
                    }

                    parent.RemoveChildren(this);
                }

                parent = value;
                IsComponent = false;
                parent.AddChildren(this);
                Domain = parent.domain;
            }
        }

        public Entity Domain
        {
            get => domain;
            private set
            {
                if (value == null)
                {
                    throw new Exception($"domain cant set null: {GetType().Name}");
                }

                if (domain == value)
                {
                    return;
                }

                domain = value;

                // 递归设置孩子的Domain
                if (children != null)
                {
                    foreach (Entity entity in children.Values)
                    {
                        entity.Domain = domain;
                    }
                }

                if (components != null)
                {
                    foreach (Entity component in components.Values)
                    {
                        component.Domain = domain;
                    }
                }
            }
        }

        public Dictionary<long, Entity> Children => children ?? ObjectPool.Instance.Fetch<Dictionary<long, Entity>>();

        public Dictionary<Type, Entity> Components =>
            Components ?? ObjectPool.Instance.Fetch<Dictionary<Type, Entity>>();

        public long Id { get; set; }
        public long InstanceId { get; protected set; }
        public bool IsDisposed => InstanceId == 0;

        public virtual void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }

            InstanceId = 0;
            if (components != null)
            {
                foreach (KeyValuePair<Type, Entity> kv in components)
                {
                    kv.Value.Dispose();
                }

                components.Clear();
                ObjectPool.Instance.Recycle(components);
                components = null;
            }

            if (children != null)
            {
                foreach (Entity child in children.Values)
                {
                    child.Dispose();
                }

                children.Clear();
                ObjectPool.Instance.Recycle(children);
                children = null;
            }

            domain = null;
            if (parent != null && !parent.IsDisposed)
            {
                if (IsComponent)
                {
                    parent.RemoveComponent(this);
                }
                else
                {
                    parent.RemoveChildren(this);
                }
            }
        }

        private void AddChildren(Entity entity)
        {
            Children.Add(entity.Id, entity);
        }

        private void RemoveChildren(Entity entity)
        {
            if (children == null)
            {
                return;
            }

            children.Remove(entity.Id);
            if (children.Count == 0)
            {
                ObjectPool.Instance.Recycle(children);
            }
        }

        public K GetChild<K>(long id) where K : Entity
        {
            if (children == null)
                return null;
            children.TryGetValue(id, out Entity child);
            return child as K;
        }

        public void RemoveChild(long id)
        {
            if (this.children == null)
            {
                return;
            }

            if (!this.children.TryGetValue(id, out Entity child))
            {
                return;
            }

            this.children.Remove(id);
            child.Dispose();
        }

        private void AddComponent(Entity component)
        {
            Components.Add(component.GetType(), component);
        }
        public K AddComponent<K>(bool isFromPool = false) where K : Entity, new()
        {
            Type type = typeof (K);
            if (this.components != null && this.components.ContainsKey(type))
            {
                throw new Exception($"entity already has component: {type.FullName}");
            }

            Entity component = Create(type, isFromPool);
            component.Id = this.Id;
            component.ComponentParent = this;


            return component as K;
        }
        private static Entity Create(Type type, bool isFromPool)
        {
            Entity component;
            if (isFromPool)
            {
                component = (Entity)ObjectPool.Instance.Fetch(type);
            }
            else
            {
                component = Activator.CreateInstance(type) as Entity;
            }
            component.IsFromPool = isFromPool;
            component.IsCreated = true;
            component.IsNew = true;
            component.Id = 0;
            return component;
        }
        private void RemoveFromComponents(Entity component)
        {
            if (components == null)
            {
                return;
            }

            components.Remove(component.GetType());
            if (components.Count == 0)
            {
                ObjectPool.Instance.Recycle(components);
                components = null;
            }
        }

        public Entity GetComponent(Type type)
        {
            if (components == null)
            {
                return null;
            }

            if (!components.TryGetValue(type, out Entity component))
            {
                return null;
            }

            return component;
        }

        public void RemoveComponent(Entity component)
        {
            if (IsDisposed)
            {
                return;
            }

            if (components == null)
            {
                return;
            }

            Type type = component.GetType();
            Entity c = GetComponent(component.GetType());
            if (c == null)
            {
                return;
            }

            if (c.InstanceId != component.InstanceId)
            {
                return;
            }

            RemoveFromComponents(c);
            c.Dispose();
        }
        public void RemoveComponent<K>() where K : Entity
            {
                if (this.IsDisposed)
                {
                    return;
                }

                if (this.components == null)
                {
                    return;
                }

                Type type = typeof(K);
                Entity c = this.GetComponent(type);
                if (c == null)
                {
                    return;
                }

                this.RemoveFromComponents(c);
                c.Dispose();
            }
        public void RemoveComponent(Type type)
        {
            if (this.IsDisposed)
            {
                return;
            }

            Entity c = this.GetComponent(type);
            if (c == null)
            {
                return;
            }

            RemoveFromComponents(c);
            c.Dispose();
        }

        public K GetComponent<K>() where K : Entity
        {
            if (this.components == null)
            {
                return null;
            }

            Entity component;
            if (!this.components.TryGetValue(typeof (K), out component))
            {
                return default;
            }

            // 如果有IGetComponent接口，则触发GetComponentSystem
            //if (this is IGetComponent)
            //{
            //    EventSystem.Instance.GetComponent(this, component);
            //}

            return (K) component;
        }
        
    }
}
