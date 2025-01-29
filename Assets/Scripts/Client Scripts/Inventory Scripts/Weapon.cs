using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game2D.Client
{
    public abstract class Weapon
    {

        public virtual void Use()
        {

        }
    }

    public class Sword : Weapon
    {
        public Sword() 
        {
            Debug.Log($"{nameof(Sword)}");
        }

        public override void Use()
        {
            
        }

    }

    public class BowArrow : Weapon
    {
        public BowArrow() 
        {
            Debug.Log($"{nameof(BowArrow)}");
        }

        public override void Use()
        {
            
        }
    }
}

