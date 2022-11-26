using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nono
{
    public class Unit : Entity
    {
        public UnitType unitType;
        public Vector3 position;
        private Quaternion rotation;

        public Vector3 Position
        {
            get => position;
            set
            {
                Vector3 oldPos = position;
                position = value;
            }
        }
        public Quaternion Rotation
        {
            get => rotation;
            set
            {
                rotation = value;
            }
        }
        public Vector3 Forward
        {
            get => Rotation * Vector3.forward;
            set => Rotation = Quaternion.LookRotation(value, Vector3.up);
        }

        protected override string ViewName => $"{GetType().Name} ({Id})";
    }
}