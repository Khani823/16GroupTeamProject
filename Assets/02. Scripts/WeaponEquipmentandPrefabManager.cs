using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEquipmentandPrefabManager : MonoBehaviour
{
    [SerializeField] private GameObject swordman;
    [SerializeField] private GameObject hammerman;
    [SerializeField] private GameObject gunman;
    [SerializeField] private GameObject bowman;


    private GameObject currentWeaponman;

    public void ChangeCharacterPrefab(GameObject newCharacterPrefab)
    { 
        if (currentWeaponman != null)
        {
            WeaponAttack currentWeaponAttack = currentWeaponman.GetComponentInChildren<WeaponAttack>();
            if(currentWeaponAttack != null)
            {
                currentWeaponAttack.ClearRangeBoxes();
	        }
            Destroy(currentWeaponman); 
	    }

        currentWeaponman = Instantiate(newCharacterPrefab, transform.position, Quaternion.identity, transform);
        WeaponAttack weaponAttack = currentWeaponman.GetComponentInChildren<WeaponAttack>();
        
	    PlayerAttackController playerAttackController = FindObjectOfType<PlayerAttackController>();
        if (playerAttackController != null)
        {
            playerAttackController.SetCurrentWeapon(weaponAttack);
        }
    }

    public void EquipSword()
    {
        ChangeCharacterPrefab(swordman);
    }


    public void EquipHammer()
    {
        ChangeCharacterPrefab(hammerman);
    }


    public void EquipBow()
    {
        ChangeCharacterPrefab(bowman);
    }


    public void EquipGun()
    {
        ChangeCharacterPrefab(gunman);
    }
}
