using Cinemachine;
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

        [SerializeField] EnemyManagerMB             m_EnemyManagerMB_Script;
        [SerializeField] bool                       m_MoveEnemy;
        [SerializeField] byte                       m_HitCount = 0;
        [SerializeField] float                      m_Speed = 5;
        [SerializeField] Vector2                    m_Direction;
        [SerializeField] CinemachineImpulseSource   m_CinemachineImpulseSource;
        [SerializeField] PlayerMB                   m_PlayerMB_Script;


        #region Monobehaviour callbacks
        private void Awake()
        {
            m_characterFactory = new CharacterFactory();
        }

        private void OnEnable()
        {
            CalculateDirectionAsynchronously();
        }

        void Start()
        {
            try
            {
                m_Character = m_characterFactory.GetCharacter(this.tag.ToString());
                m_PlayerMB_Script = GameObject.FindObjectOfType<PlayerMB>();

                m_Direction = new Vector2(Random.Range(-20, 20),
                                            Random.Range(-20, 20));

                CalculateDistanceAsync();

                m_EnemyManagerMB_Script = GameObject.FindObjectOfType<EnemyManagerMB>();
            }
            catch
            {
                // Debug.Log("<color=red>Null exception</color>");
            }
        }

        

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.tag == "Sword")
            {
                UpdateHitCount(collider, null);   
            }
            if (collider.tag == "Obstacle")
            {
                CalculateDirectionAsynchronously();
            }
            if (collider.tag == "Arrow")
            {
                UpdateHitCount(collider, null);
            }
        }

        private void UpdateHitCount(Collider2D collider = null, Collision2D collision = null)
        {
            m_HitCount++;
            if (m_HitCount >= 3)
            {
                m_HitCount = 0;
                GameManagerMB.Instance.UpdatePlayerPoints(new Player());
                CinemachineShakeManagerMB.Instance.CameraShake(m_CinemachineImpulseSource);
                StartCoroutine(DestroyGameObject());
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
        }
        #endregion


        bool directionCalculating = true;
        async void CalculateDirectionAsynchronously()
        {
            if(m_MoveEnemy == false) 
                return;

            while (directionCalculating)
            {
                await Task.Delay(5000);
                m_Direction = new Vector2(Random.Range(-20, 20),
                                            Random.Range(-20, 20));
            }
        }

        bool distanceCalculating = true;
        [SerializeField] float  m_Distance;
        [SerializeField] bool   m_PlayerAsTarget;

        async void CalculateDistanceAsync()
        {
            while (distanceCalculating)
            {
                if (m_PlayerMB_Script != null)
                {
                    m_Distance = Vector2.Distance(transform.position, m_PlayerMB_Script.transform.position);
                    if (m_Distance < 3)
                    {
                        m_Direction = new Vector2(m_PlayerMB_Script.transform.position.x, m_PlayerMB_Script.transform.position.y);
                        m_PlayerAsTarget = true;
                    }
                    else
                    {
                        m_PlayerAsTarget = false;
                    }
                }
                await Task.Delay(200); 
            }
        }

        IEnumerator DestroyGameObject()
        {
            distanceCalculating = false;    
            yield return new WaitForSeconds(0.02f);
            Destroy(gameObject);
        }


    }
}

