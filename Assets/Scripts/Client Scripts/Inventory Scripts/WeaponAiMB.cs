using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game2D.Client
{
    public class WeaponAiMB : MonoBehaviour
    {
        [SerializeField] EnemyManagerMB m_EnemyManager_Script;
        [SerializeField] Transform      m_Player_Transform;   

        void Start()
        {
            if (m_EnemyManager_Script == null) 
            {
                m_EnemyManager_Script = GameObject.FindObjectOfType<EnemyManagerMB>();
            }    
        }

        
        void Update()
        {
            Transform closestEnemy = FindClosestEnemy();
            Debug.Log($"Closest Enemy {closestEnemy.name}");
        }

        Transform FindClosestEnemy()
        {
            Transform enemy = null;
            var minDistance = Mathf.Infinity;

            /*foreach (GameObject e in m_EnemyManager_Script.m_Enemies_GameObject) 
            {
                float dist = Vector2.Distance(m_Player_Transform.position, e.transform.position);
                if(dist < minDistance)
                {
                    enemy = e.transform;
                    minDistance = dist;
                }
            }*/

            return enemy;
        }


        
    }

}
