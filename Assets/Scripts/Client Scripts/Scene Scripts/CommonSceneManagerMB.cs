using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Game2D.Client
{
    public class CommonSceneManagerMB : MonoBehaviour
    {

        [SerializeField] SceneHandlerMB.Name sceneName;

        private void Start()
        {
            LoadSceneAdditively((int)sceneName);
        }


        public void LoadSceneAdditively(int sceneIndexToLoad)
        {
            SceneManager.LoadSceneAsync(sceneIndexToLoad, LoadSceneMode.Additive);
        }

        public void UnLoadSceneAdditively(int sceneIndexToUnload)
        {
            SceneManager.UnloadSceneAsync(sceneIndexToUnload);
        }
    }

}
