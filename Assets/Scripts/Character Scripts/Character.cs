using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;


namespace Game2D.Client
{
    public abstract class Character
    {
        public virtual void Move(Rigidbody2D rigidbody2D, Vector2 direction, float speed)
        {

        }
        public virtual void Attack()
        {

        }

        public virtual void AdjustDirection(int direction, WeaponManagerMB weaponManagerMB, SpriteRenderer spriteRenderer)
        {

        }
    }

    public class Player : Character 
    {
        public byte MaxHealth = 100;
        public byte MinHealth = 25;

        public override void Move(Rigidbody2D rigidbody2D, Vector2 direction, float speed)
        {
            rigidbody2D.MovePosition(rigidbody2D.position + direction * (Time.fixedDeltaTime * speed));
        }
        public override void Attack() 
        {

        }

        public override void AdjustDirection(int direction, WeaponManagerMB weaponManagerMB = null, SpriteRenderer spriteRenderer = null)
        {
            if (direction == -1)
            {
                if (weaponManagerMB == null)
                    return;

                if(weaponManagerMB.m_CurrentWeaponMB.type == WeaponMB.Type.Sword)
                {
                    weaponManagerMB.Rotate(0, 180, 0);
                } 
            }
            else
            {
                if (weaponManagerMB.m_CurrentWeaponMB.type == WeaponMB.Type.Sword)
                {
                    weaponManagerMB.Rotate(0, 0, 0);
                }
            }
        }
    }
    
    public class Enemy : Character 
    {
        public override void Move(Rigidbody2D rigidbody2D, Vector2 direction, float speed)
        {
            rigidbody2D.MovePosition(rigidbody2D.position + direction * (Time.fixedDeltaTime * speed));
        }
        public override void Attack() 
        {
            
        }
        public override void AdjustDirection(int direction, WeaponManagerMB weaponManagerMB, SpriteRenderer spriteRenderer)
        {
            
        }
    }

}
