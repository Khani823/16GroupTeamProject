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
            Debug.Log("Destroying current weapon: " + currentWeaponman.name);
            Destroy(currentWeaponman);
        }

        currentWeaponman = Instantiate(newCharacterPrefab, transform.position, Quaternion.identity, transform);
        Debug.Log("New weapon equipped: " + currentWeaponman.name);

        PlayerScript playerScript = FindObjectOfType<PlayerScript>();
        if (playerScript != null)
        {
            playerScript.OnWeaponChanged();
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
