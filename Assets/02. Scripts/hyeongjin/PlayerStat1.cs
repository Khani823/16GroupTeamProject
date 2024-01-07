using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStat1 : MonoBehaviour
{   
    public int maxHealth = 100;
    public int currentHealth {  get; private set; }
    public Stats damage;
    public Stats deffense;

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
    void OnEquipmentChanged(EquipmentClass newitem, EquipmentClass olditem)
    {
        if (newitem != null)
        {
        deffense.AddModifier(newitem.Defense);
        damage.AddModifier(newitem.Damage);
        }

        if (olditem != null)
        {
            deffense.RemoveModifier(olditem.Defense);
            damage.RemoveModifier(olditem.Damage);
        }
    }
    public void TakeDamage(int damage)
    {
        damage -= deffense.GetValue();
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

