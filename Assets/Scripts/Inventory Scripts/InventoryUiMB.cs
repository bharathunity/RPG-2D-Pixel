using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Game2D.Client
{
    public class InventoryUiMB : MonoBehaviour
    {
        [SerializeField] WeaponManagerMB    m_WeaponManagerMB;
        [SerializeField] Image              m_WeaponUseImage;
        [SerializeField] Transform[]        m_Weapons;
        [SerializeField] Sprite[]           m_WeaponsSprite;

        void Start()
        {

        }


        /// <summary>
        /// Attach this to Each Inventory item OnButtonClick() event.
        /// </summary>
        /// <param name="index"></param>
        public void ToggleActiveWeapon(int index)
        {
            for (int i = 0; i < m_Weapons.Length; i++) {
                m_Weapons[i].GetChild(0).gameObject.SetActive(false);
            }
            m_Weapons[index].GetChild(0).gameObject.SetActive(true);

            // m_WeaponUseImage.transform.parent.gameObject.SetActive(true);
            m_WeaponUseImage.sprite = m_WeaponsSprite[index];

            m_WeaponManagerMB.ChooseWeaponFromList(index);
        }
    }

}
