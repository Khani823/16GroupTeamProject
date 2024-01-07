using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStat1 : MonoBehaviour
{   
    public int maxHealth = 100;
    public int currentHealth {  get; private set; }
    public Stats damage;
    public Stats defense;

    public void Awake()
    {
        currentHealth = maxHealth;
    }
    public void Start()
    {
        EquipmentManager.Instance.onEquipmentChanged += OnEquipmentChanged;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }
    void OnEquipmentChanged(ItemClass newitem, ItemClass olditem)
    {
        if (newitem != null)
        {
        defense.AddModifier(newitem.GetEquipment().Defense);
        damage.AddModifier(newitem.GetEquipment().Damage);
        }

        if (olditem != null)
        {           
            defense.RemoveModifier(olditem.GetEquipment().Defense);
            damage.RemoveModifier(olditem.GetEquipment().Damage);
        }
        if (olditem == null)
        {
            Debug.Log("null");
        }
    }
    public void TakeDamage(int damage)
    {
        damage -= defense.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        Debug.Log(transform.name + "takes" + damage + "damage");


        currentHealth -= damage;

        if (currentHealth < 0)
        {
            Die();
        }
    }
    public virtual void Die()
    {
        Debug.Log(transform.name + "died");
    }
}

