using UnityEngine;

namespace Nono
{
    public abstract class ConfigurableUpdateComponent : MonoBehaviour
    {
        private UpdateMode _updateMode = UpdateMode.Update;
        private bool _registered = false;
        public UpdateMode updateMode
        {
            get { return _updateMode; }
            set
            {
                if (_updateMode != value)
                {
                    if (_registered)
                    {
                        RuntimeUtilities.RemoveUpdate(_updateMode, OnUpdate);
                        RuntimeUtilities.AddUpdate(value, OnUpdate);

#if UNITY_EDITOR
                        _addedUpdateMode = value;
#endif
                    }
                    
                    _updateMode = value;
                }
            }
        }
        protected abstract void OnUpdate();


        protected virtual void OnEnable()
        {
            RuntimeUtilities.AddUpdate(_updateMode, OnUpdate);
            _registered = true;

#if UNITY_EDITOR
            _addedUpdateMode = _updateMode;
#endif
        }


        protected virtual void OnDisable()
        {
            RuntimeUtilities.RemoveUpdate(_updateMode, OnUpdate);
            _registered = false;
        }


#if UNITY_EDITOR

        UpdateMode _addedUpdateMode;
        protected virtual void OnValidate()
        {
            if (_registered && _addedUpdateMode != _updateMode)
            {
                RuntimeUtilities.RemoveUpdate(_addedUpdateMode, OnUpdate);
                RuntimeUtilities.AddUpdate(_updateMode, OnUpdate);
                _addedUpdateMode = _updateMode;
            }
        }
#endif
    }
}