using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Game2D.Client
{
    public class InventoryUiMB : MonoBehaviour
    {

        public static InventoryUiMB Instance;

        [SerializeField] WeaponManagerMB    m_WeaponManagerMB;
        [SerializeField] Image              m_EquippedWeapon_Image;
        //[SerializeField] int                m_EquippedWeapon_Index;
        [SerializeField] Transform[]        m_Weapons;
        [SerializeField] Sprite[]           m_WeaponsSprite;

        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {

        }

        private void Update()
        {
            if(m_WeaponManagerMB == null)
            {
                m_WeaponManagerMB = FindObjectOfType<WeaponManagerMB>();
            }
        }

        /// <summary>
        /// Enable or Disable weapon UI on the canvas space.
        /// </summary>
        /// <param name="index">
        /// 0 -> Sword
        /// 1 -> Bow
        /// </param>
        public void ToggleWeaponUiFromInventory(int index, bool value)
        {
            m_Weapons[index].gameObject.SetActive(value);
        }

        /// <summary>
        /// Attach this to Each Inventory item OnButtonClick() event.
        /// </summary>
        /// <param name="index"></param>
        public void SelectWeaponFromUI_OnButtonClick(int index)
        {
            for (int i = 0; i < m_Weapons.Length; i++) {
                m_Weapons[i].GetChild(0).gameObject.SetActive(false);
            }
            m_Weapons[index].GetChild(0).gameObject.SetActive(true);

            if (!m_EquippedWeapon_Image.gameObject.activeInHierarchy) 
            {
                m_EquippedWeapon_Image.transform.parent.gameObject.SetActive(true);
            }
            // Image from the Right Joystick Knob handle
            m_EquippedWeapon_Image.sprite = m_WeaponsSprite[index];

            //m_EquippedWeapon_Index = index;

            m_WeaponManagerMB.UpdateWeaponOnPlayer(index);
        }
    }

}
