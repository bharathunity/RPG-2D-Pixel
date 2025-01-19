using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game2D.Client
{

    public class PlayerMB : MonoBehaviour 
    {
        public delegate void PlayerMBDelegate();
        public static PlayerMBDelegate PlayerMBSignature;

        #region State Machine
        public enum State
        {
            Idle = 0,
            Walk,
            Run,
            Death
        }

        public State playerState;

        public State GetPlayerState() => playerState;

        internal void SetPlayerState(State state)
        {
            playerState = state;
        }
        #endregion

        /// <summary>
        /// Character Factory 
        /// </summary>
        CharacterFactory m_characterFactory;

        /// <summary>
        /// Character
        /// </summary>
        Character character;

        Player player;

        [SerializeField] WeaponManagerMB    m_WeaponManagerMB;
        [SerializeField] Rigidbody2D        m_Rigidbody2D;
        [SerializeField] float              m_MoveSpeed = 1;
        [SerializeField] SpriteRenderer     m_SpriteRenderer;
        [SerializeField] Animator           m_Animator;
        [SerializeField] AudioSource        m_AudioSource;
        [SerializeField] int                m_EnemyKillCount = 0;
        [SerializeField] int                m_CurrentHealth;


        /// <summary>
        /// Move Direction.
        /// </summary>
        [SerializeField] Vector2 m_MovementDirection;

        

        #region Monobehaviour callbacks
        private void Awake()
        {
            m_characterFactory = new CharacterFactory();
        }

        private void OnEnable()
        {
            PlayerMBSignature += UpdatePlayerPoints;
        }

        private void OnDisable()
        {
            PlayerMBSignature -= UpdatePlayerPoints;
        }



        void Start()
        {
            try
            {
                GameSceneManagerMB.Instance.ResumeGame();
                character = m_characterFactory.GetCharacter(this.tag.ToString());
                player = character as Player;
                m_CurrentHealth = player.MaxHealth;
                PlayerDataInfoUiMB.Instance.UpdatePlayerSlider(m_CurrentHealth);
                Debug.Log($"Character : {character}");
                SetPlayerState(State.Idle);
            }
            catch
            {
                Debug.Log("<color=red>Null exception</color>");
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.collider.tag == "Enemy")
            {
                if(m_CurrentHealth > 0)
                {
                    m_CurrentHealth -= 5;
                }
                if(m_CurrentHealth <= 0)
                {
                    m_CurrentHealth = player.MaxHealth;
                }
                PlayerDataInfoUiMB.Instance.UpdatePlayerSlider(m_CurrentHealth);
                Debug.Log("Player collided with the enemy!");
            }
        }

        void Update()
        {
            if(playerState != State.Death)
            {
                m_MovementDirection = InputControllerMB.Instance.Input_Controller.Player.Move.ReadValue<Vector2>();

                m_Animator.SetFloat("X", m_MovementDirection.x);
                m_Animator.SetFloat("Y", m_MovementDirection.y);

                if (m_MovementDirection.x > 0.8f || m_MovementDirection.y > 0.8f || m_MovementDirection.x < -0.8f || m_MovementDirection.y < -0.8f)
                {
                    m_MoveSpeed = 4;
                    SetPlayerState(State.Run);
                }
                else if (m_MovementDirection.x > 0.3f || m_MovementDirection.y > 0.3f || m_MovementDirection.x < -0.3f || m_MovementDirection.y < -0.3f)
                {
                    m_MoveSpeed = 2;
                }
                else if (m_MovementDirection.x > 0.01f || m_MovementDirection.y > 0.01f || m_MovementDirection.x < -0.01f || m_MovementDirection.y < -0.01f)
                {
                    m_MoveSpeed = 1;
                    SetPlayerState(State.Walk);
                }
                else
                {
                    SetPlayerState(State.Idle);
                }

                // Player direction (Left or Right)
                Vector2 direction = InputControllerMB.Instance.Input_Controller.Player.Direction.ReadValue<Vector2>();
                if (direction.x < -0.01)
                {
                    m_SpriteRenderer.flipX = true;
                    character.AdjustDirection(-1, m_WeaponManagerMB, m_SpriteRenderer);
                }
                else if (direction.x > 0.01)
                {
                    m_SpriteRenderer.flipX = false;
                    character.AdjustDirection(1, m_WeaponManagerMB, m_SpriteRenderer);
                }

                /*// Sword
                if (m_WeaponManagerMB.m_CurrentWeaponMB != null && m_WeaponManagerMB.m_CurrentWeaponMB.type == WeaponMB.Type.Sword)
                {
                    m_Character.AdjustDirection(FingerSwipeDetectionMB.SwipingDirection, m_WeaponManagerMB, m_SpriteRenderer);
                }
                // Bow
                else if (m_WeaponManagerMB.m_CurrentWeaponMB != null && m_WeaponManagerMB.m_CurrentWeaponMB.type == WeaponMB.Type.Bow)
                {
                    // Bow direction
                    Vector2 bowDirection = InputControllerMB.Instance.Input_Controller.BowArrow.Movement.ReadValue<Vector2>();
                    if (bowDirection.x < -0.01)
                    {
                        m_SpriteRenderer.flipX = true;
                    }
                    else if(bowDirection.x >= 0)
                    {
                        m_SpriteRenderer.flipX = false;
                    }
                }*/
            }
        }


        private void FixedUpdate()
        {
            if (playerState != State.Death)
            {
                character.Move(m_Rigidbody2D, m_MovementDirection, m_MoveSpeed);
            }
        }
        #endregion


        void UpdatePlayerPoints()
        {
            if (m_EnemyKillCount < 100)
            {
                m_EnemyKillCount += 1;
                PlayerDataInfoUiMB.Instance.UpdateEnemy1KillCount_Text(m_EnemyKillCount);
            }
            else
            {
                Debug.Log("<color=yellow>Max kill count is 99</yellow>");
            }
            
            
        }

        
    }
}

