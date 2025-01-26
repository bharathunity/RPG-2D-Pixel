using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Game2D.Client
{
    public class SwordMB : WeaponMB
    {
        [SerializeField] WeaponManagerMB        m_WeaponManagerMB;

        [field: SerializeField] public Sprite   m_Sprite { get; private set; }
        [SerializeField] Animator               m_Animator;
        [SerializeField] BoxCollider2D          m_BoxCollider2D;
        private int m_HitCount;

        private void OnEnable()
        {
            InputControllerMB.Instance.Input_Controller.Sword.Swing.started     += _ => SwingStarted();
            InputControllerMB.Instance.Input_Controller.Sword.Swing.canceled    += _ => SwingCancelled();
        }


        
        private void OnDisable()
        {
            InputControllerMB.Instance.Input_Controller.Sword.Swing.started     -= _ => SwingStarted();
            InputControllerMB.Instance.Input_Controller.Sword.Swing.canceled    -= _ => SwingCancelled();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Enemy")
            {
                m_WeaponManagerMB.PlayAudio();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Enemy")
            {
                // m_WeaponManagerMB.StopAudio();
            }
        }

        public override void Attack()
        {
            if (InAttack)
            {
                m_Animator.SetTrigger("sword");
            }
            /*else
            {
                m_Animator.ResetTrigger("sword");
            }*/
        }

        public void SwingStarted()
        {
            
            InAttack = true;
        }
        
        public void SwingCancelled()
        {
            InAttack = false;
        }

      
        /// <summary>
        /// Attach this to the Animation Event
        /// </summary>
        public void EnableCollider()
        {
            m_BoxCollider2D.enabled = true;
        }


        /// <summary>
        /// Attach this to the Animation Event.
        /// </summary>
        public void DisableCollider()
        {
            m_BoxCollider2D.enabled = false;
        }
    }
}

