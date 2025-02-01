using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;


namespace Game2D.Client
{

    public class EnemyManagerMB : MonoBehaviour
    {
        [SerializeField] string                             m_Enemy_Prefab_Addressable = "Assets/Prefabs/Enemy1.prefab";
        [SerializeField] byte                               m_Enemy1Count = 5;
        [SerializeField] Vector2[]                          m_EnemySpawnPositions;
       

        async void Start()
        {
            var handle = Addressables.LoadAssetAsync<GameObject>(m_Enemy_Prefab_Addressable);
            await handle.Task;
            if (handle.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
            {
                for(int i = 0; i < m_Enemy1Count; i++)
                {
                    Instantiate(handle.Result, new Vector3(m_EnemySpawnPositions[i].x, m_EnemySpawnPositions[i].y, 0), Quaternion.identity);
                }
                Debug.Log("success : Enemy loaded successfully!");
            }
            else
            {
                Debug.Log("error : Failed to load enemy!");
            }
        }
    }
}

