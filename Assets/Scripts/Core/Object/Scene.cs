namespace Nono
{
    public class Scene : Entity
    {
        public int Zone { get; }
        public SceneType SceneType { get; }
        public string Name { get; set; }

        public Scene(long instanceId, int zone, SceneType sceneType, string name, Entity parent)
        {
            Id = instanceId;
            InstanceId = instanceId;
            Zone = zone;
            SceneType = sceneType;
            Name = name;
            IsCreated = true;
            IsNew = true;
            Parent = parent;
            Domain = this;
            IsRegister = true;
        }
        public Scene(long id, long instanceId, int zone, SceneType sceneType, string name, Entity parent)
        {
            Id = id;
            InstanceId = instanceId;
            Zone = zone;
            SceneType = sceneType;
            Name = name;
            IsCreated = true;
            IsNew = true;
            Parent = parent;
            Domain = this;
            IsRegister = true;
        }
        public new Entity Domain
        {
            get => this.domain;
            set => this.domain = value;
        }

        public new Entity Parent
        {
            get
            {
                return this.parent;
            }
            set
            {
                if (value == null)
                {
                    return;
                }

                this.parent = value;
                this.parent.Children.Add(this.Id, this);
            }
        }
        
        public Scene Get(long id)
        {
            if (this.Children == null)
            {
                return null;
            }

            if (!this.Children.TryGetValue(id, out Entity entity))
            {
                return null;
            }

            return entity as Scene;
        }
        
        protected override string ViewName => $"{GetType().Name} ({SceneType})";

        public override void Dispose()
        {
            
        }
    }
}