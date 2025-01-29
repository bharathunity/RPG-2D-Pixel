using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game2D.Client
{
    public class WeaponMB : MonoBehaviour
    {
        public enum Type
        {
            Sword = 0,
            Bow
        }

        public Type type;

        [field : SerializeField] internal int Priority { get; private set; }
        [field : SerializeField] public bool InAttack { get; protected set; }

        

        public virtual void Attack() 
        { 
        
        }

        public virtual void Rotate()
        {

        }
    }

}
