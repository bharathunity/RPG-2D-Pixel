using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Game2D.Client
{
    public class PlayerManagerMB : MonoBehaviour
    {
        [SerializeField] string m_Player_Prefab_Addressable = "Assets/Prefabs/Player.prefab";
        [field: SerializeField] public Vector2 m_InstantiatingPosition { get; private set; }

        [SerializeField] PlayerMB           m_PlayerMB_Script;
        [SerializeField] WeaponManagerMB    m_WeaponManagerMB_Script;
        [SerializeField] Transform          m_ClosestEnemy;
        [SerializeField] EnemyMB[]          m_EnemiesGameObject;

        

        async void Start()
        {
            var handle = Addressables.LoadAssetAsync<GameObject>(m_Player_Prefab_Addressable);
            await handle.Task;

            if (handle.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
            {
                // Instantiating the enemies.
                Instantiate(handle.Result, new Vector3(m_InstantiatingPosition.x, m_InstantiatingPosition.y, 0), Quaternion.identity);
                m_PlayerMB_Script           = FindObjectOfType<PlayerMB>();
                m_WeaponManagerMB_Script    = FindObjectOfType<WeaponManagerMB>();
                Debug.Log("success : Enemy loaded successfully!");
            }
            else
            {
                Debug.Log("error : Failed to load enemy!");
            }

        }

        private void Update()
        {
            // m_ClosestEnemy = FindClosestEnemy();
        }

        public void LoadEnemiesComponenetIntoArray()
        {
            m_EnemiesGameObject = GameObject.FindObjectsByType<EnemyMB>(FindObjectsSortMode.None);
        }

        /// <summary>
        /// Find Closest Enemy to the Player
        /// </summary>
        /// <returns></returns>
        Transform FindClosestEnemy()
        {
            Transform enemy = null;
            float m_MinDistance = Mathf.Infinity;

            foreach (EnemyMB e in m_EnemiesGameObject)
            {
                float dist = Vector2.Distance(m_PlayerMB_Script.transform.position, e.transform.position);
                if (dist < m_MinDistance)
                {
                    enemy = e.transform;
                    m_MinDistance = dist;
                    // m_WeaponManagerMB_Script.UpdateWeaponOnPlayer(0);
#if UNITY_EDITOR
                    Debug.DrawLine(m_PlayerMB_Script.transform.position, e.transform.position, Color.red);
#endif
                }
                else
                {
                    // m_WeaponManagerMB_Script.UpdateWeaponOnPlayer(1);
                }
            }

            return enemy;
        }

    }

}
