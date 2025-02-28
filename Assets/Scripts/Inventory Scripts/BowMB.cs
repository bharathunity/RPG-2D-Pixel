using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game2D.Client
{
    public class BowMB : WeaponMB
    {
        [SerializeField] WeaponManagerMB        m_WeaponManagerMB;

        [SerializeField] ArrowMB                m_Arrow_Prefab;

        [field: SerializeField] public Sprite   m_Sprite { get; private set; }
        [SerializeField] Animator               m_Animator;
        [SerializeField] SpriteRenderer         m_SpriteRenderer;

        [SerializeField] Transform              m_Player_Transform;
        [SerializeField] SpriteRenderer         m_Player_SpriteRenderer;

        [SerializeField] bool                   m_arrowInstantiated = false;
        [SerializeField] float                  m_rotationSpeed = 2f;

        float   rotationDegree;
        float   lastRotationDegree;
        bool    lastRotationStored;

        private void OnEnable()
        {
            transform.rotation = Quaternion.Euler(0, 0, lastRotationDegree);
        }

        public override void Attack()
        {
            if (InputControllerMB.Instance.Input_Controller.BowArrow.ArrowRelease.IsPressed())
            {
                if (m_arrowInstantiated)
                    return;

                ArrowMB arrowObject = Instantiate(m_Arrow_Prefab, transform.position + transform.right, transform.rotation);
                /*if (m_SpriteRenderer.flipX)
                {
                    
                    arrowObject = Instantiate(m_Arrow_Prefab, transform.position - transform.right, transform.rotation);
                    arrowObject.transform.rotation = Quaternion.Euler(0, 180f,0);
                    // arrowObject.GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                {
                    arrowObject = Instantiate(m_Arrow_Prefab, transform.position + transform.right, transform.rotation);
                    arrowObject.transform.rotation = Quaternion.Euler(0, 0f, 0);
                    // arrowObject.GetComponent<SpriteRenderer>().flipX = false;
                }*/
                

                m_arrowInstantiated = true;
                StartCoroutine(ResetArrowInstantiatingFlag());

            }
        }

        public override void Rotate()
        {
            Vector2 moveDirection = InputControllerMB.Instance.Input_Controller.BowArrow.Movement.ReadValue<Vector2>();

            if (m_Player_SpriteRenderer.flipX)
            {
                if (moveDirection == Vector2.zero)
                {
                    rotationDegree = 180f;
                }
                else
                {
                    rotationDegree = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
                }
            }
            else if(!m_Player_SpriteRenderer.flipX)
            {
                rotationDegree = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            }
            transform.rotation = Quaternion.Euler(0, 0, rotationDegree);
        }

        public void ResetBowLastRotationValue()
        {
            if (m_Player_SpriteRenderer.flipX == true)
            {
                
                lastRotationStored = false;
            }
        }

        /// <summary>
        /// Add this to the Event Trigger OnPointerExit of Righ stick Knob
        /// </summary>
        public void StoreBowLastRotationValue()
        {
            if(m_Player_SpriteRenderer.flipX == true)
            {
                rotationDegree = 180;
                lastRotationStored = true;
            }
            
        }


        float deltaSeconds = 0;
        float delayInSeconds = 0;
        private bool arrowInstantiated;

        void InstantiateArrowWithDelay()
        {
            deltaSeconds += Time.deltaTime;
            if (deltaSeconds > 1) 
            {
                delayInSeconds += 1;
                if(delayInSeconds > 1f)
                {
                    Instantiate(m_Arrow_Prefab, this.transform.position + new Vector3(0.3f, 0, 0), this.transform.rotation);
                }
                deltaSeconds = 0;
            }
        }


        IEnumerator ResetArrowInstantiatingFlag()
        {
            yield return new WaitForSeconds(0.5f);
            m_arrowInstantiated = false;
        }

    }
}


