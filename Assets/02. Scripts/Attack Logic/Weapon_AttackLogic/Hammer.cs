using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : WeaponAttack
{
    public override void Attack(Vector2 direction)
    {
        base.Attack(direction);
    }

    public override void ShowAttackRange(Vector2 direction)
    {
        for(float i = 1; i<=range; i++)
        {
            Vector2 basePosition = (Vector2)transform.position + (direction * i);
            Vector2 tile = new Vector2(Mathf.Round(basePosition.x * 2) / 2, Mathf.Round(basePosition.y * 2) / 2);
            GameObject showingBox = Instantiate(rangeBox, tile, Quaternion.identity);
            rangeBoxes.Add(showingBox);
        }
    }

    protected override int CalculateFinalDamage(CharacterStatsSO attackerStats, CharacterStatsSO defenderStats, Vector2 attackDirection, Vector2 targetPosition)
    {
        int baseDamage = DamageCalculation(attackerStats, defenderStats);
        float damageModifier = UnityEngine.Random.Range(0.9f, 1.0f);
        return Mathf.RoundToInt(baseDamage * damageModifier);
    }
}