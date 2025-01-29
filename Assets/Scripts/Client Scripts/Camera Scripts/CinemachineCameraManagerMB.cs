using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game2D.Client
{
    public class CinemachineCameraManagerMB : MonoBehaviour
    {

        public static CinemachineCameraManagerMB Instance;  

        [SerializeField] CinemachineVirtualCamera m_CinemachineVirtualCamera;
        [SerializeField] CinemachineStateDrivenCamera m_CinemachineStateDrivenCamera;

        private void Awake()
        {
            Instance = this;
        }


        void Start()
        {
            // UpdateTarget(GameObject.FindObjectOfType<PlayerMB>().transform);
        }


        private void Update()
        {
            
        }

        public void UpdateTarget(Transform target)
        {
            m_CinemachineVirtualCamera.Follow = target;
            m_CinemachineStateDrivenCamera.Follow = target;
        }

       
    }
}

