using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;


namespace Game2D.Client
{
    public class EnemyMB : MonoBehaviour
    {
        /// <summary>
        /// Character Factory 
        /// </summary>
        CharacterFactory m_characterFactory;

        /// <summary>
        /// Character
        /// </summary>
        Character m_Character;

        [SerializeField] bool           m_MoveEnemy;
        [SerializeField] ParticleSystem m_ParticleSystem;
        [SerializeField] byte           m_HitCount = 0;
        [SerializeField] float          m_Speed = 5;
        [SerializeField] Vector2        m_Direction;


        #region Monobehaviour callbacks
        private void Awake()
        {
            m_characterFactory = new CharacterFactory();
        }

        private void OnEnable()
        {
            InvokeRepeating(nameof(UpdateDirection), 0, 2f);  
        }

        void Start()
        {
            try
            {
                m_Character = m_characterFactory.GetCharacter(this.tag.ToString());
                Debug.Log($"Character : {m_Character}");
                m_Direction = new Vector2(transform.position.x, transform.position.y);
            }
            catch
            {
                Debug.Log("<color=red>Null exception</color>");
            }
        }

        

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.tag == "Sword")
            {
                UpdateHitCount(collider, null);   
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.collider.tag == "Obstacle")
            {
                UpdateDirection();
            }
            if(collision.collider.tag == "Arrow")
            {
                UpdateHitCount(null, collision);
            }
            
        }

        private void UpdateHitCount(Collider2D collider = null, Collision2D collision = null)
        {
            m_HitCount++;
            if (m_HitCount >= 3)
            {
                m_HitCount = 0;
                m_ParticleSystem.Play();
                GameSceneManagerMB.Instance.UpdatePlayerPoints(new Player());
                Destroy(gameObject, 0.25f);
            }
            if(collider != null)
            {
                m_Direction = transform.position + (transform.position - collider.transform.position).normalized;
                return;
            }
            m_Direction = transform.position + (transform.position - collision.transform.position).normalized;

        }

        private void Update()
        {
            transform.position = Vector2.MoveTowards(transform.position, m_Direction, Time.deltaTime * m_Speed);
            if (Mathf.Approximately(transform.position.x, m_Direction.x))
            {
                UpdateDirection();
            }
        }
        #endregion


        void UpdateDirection()
        {
            if(m_MoveEnemy == false) 
                return;
            m_Direction = new Vector2(
                Random.Range(-5,5),
                Random.Range(-5,5));
        }

        
    }
}

