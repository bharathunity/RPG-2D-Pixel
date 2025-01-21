using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game2D.Client
{
    public class CinemachineShakeManager : MonoBehaviour
    {

        public static CinemachineShakeManager Instance;

        [SerializeField] float m_ShakeForce = 1.0f;


        private void Awake()
        {
            Instance = this;
        }

        public void CameraShake(CinemachineImpulseSource cinemachineImpulseSource)
        {
            cinemachineImpulseSource.GenerateImpulseWithForce(m_ShakeForce);
        }
    }
}

