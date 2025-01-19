using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game2D.Client
{
    [RequireComponent(typeof(AudioSource))]
    public class WeaponManagerMB : MonoBehaviour
    {
        [field: SerializeField] public WeaponMB m_CurrentWeaponMB { get; private set; }
        [SerializeField] AudioSource            m_AudioSource;
        [SerializeField] WeaponMB[]             m_WeaponsMB;
        [SerializeField] AudioClip[]            m_AudioClips;
        
        void Start()
        {
            
        }

        void Update()
        {
            if (m_CurrentWeaponMB == null) return;
            m_CurrentWeaponMB.Attack();
            m_CurrentWeaponMB.Rotate();
        }

        public WeaponMB ChooseWeaponFromList(int index)
        {
            // Check for current weapon MB script
            if(m_CurrentWeaponMB != null)
            {
                m_CurrentWeaponMB.gameObject.SetActive(false);
                m_CurrentWeaponMB = null;
            }
            
            // Update current weapon
            m_CurrentWeaponMB = m_WeaponsMB[index];

            // Enable current weapon
            m_CurrentWeaponMB.gameObject.SetActive(true);

            // Assign audio clips
            m_AudioSource.clip = m_AudioClips[index];

            // Returns current weapon
            return m_CurrentWeaponMB;
        }

        internal void PlayAudio()
        {
            m_AudioSource.Play();
        }

        internal void StopAudio()
        {
            m_AudioSource.Stop();
        }

        internal void Rotate(float x, float y, float z)
        {
            transform.rotation = Quaternion.Euler(x, y, z);
        }

    }

}
