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

        async void Start()
        {
            var handle = Addressables.LoadAssetAsync<GameObject>(m_Player_Prefab_Addressable);
            await handle.Task;

            if (handle.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
            {
                Instantiate(handle.Result, new Vector3(m_InstantiatingPosition.x, m_InstantiatingPosition.y, 0), Quaternion.identity);
                Debug.Log("success : Enemy loaded successfully!");
            }
            else
            {
                Debug.Log("error : Failed to load enemy!");
            }

        }

    }

}
