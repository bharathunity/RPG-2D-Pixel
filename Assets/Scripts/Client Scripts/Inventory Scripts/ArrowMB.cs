using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


namespace Game2D.Client
{
    public class ArrowMB : MonoBehaviour
    {

        [SerializeField] Rigidbody2D        m_rigidbody2D;
        [SerializeField] PolygonCollider2D  m_collider2D;
        [SerializeField] SpriteRenderer     m_spriteRenderer;
        [SerializeField] float              m_BulletSpeed = 40f;
        [SerializeField] float              m_RightOffset = 2f;

        private void OnEnable()
        {
            Task.Delay(200);
            m_collider2D.enabled = true;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            /*if (collision.collider.CompareTag("Enemy") || collision.collider.CompareTag("Obstacle"))
            {
                // GameSceneManagerMB.Instance.UpdatePlayerPoints(new Player());
                Destroy(gameObject);
            }*/
            
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Obstacle") || collision.CompareTag("Enemy"))
            {
                Destroy(gameObject);
            }

        }


        private void Update()
        {
            if(transform.position.x > 25f || transform.position.x < -25f)
            {
                Destroy(gameObject);
            }
        }


        private void FixedUpdate()
        {
            m_rigidbody2D.velocity = (transform.right) * m_BulletSpeed;

            // m_rigidbody2D.velocity = (transform.right) * m_BulletSpeed;
            /*if(m_spriteRenderer.flipX)
                m_rigidbody2D.velocity = (transform.right) * m_BulletSpeed;
            else
                m_rigidbody2D.velocity = -(transform.right) * m_BulletSpeed;*/
        }

        private void OnDisable()
        {
            m_collider2D.enabled = false;
        }


    }
}

