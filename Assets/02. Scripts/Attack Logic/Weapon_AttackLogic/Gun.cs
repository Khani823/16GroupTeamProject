using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Gun : WeaponAttack
{
    public override void Attack(Vector2 direction)
    {
        CheckAttackRange(direction);
        ClearRangeBoxes();
    }

    public override void ShowAttackRange(Vector2 direction)
    {
        for (float i = 1; i <= range; i++)
        {
            Vector2 basePosition = (Vector2)transform.position + (direction * i);
            Vector2 tile = new Vector2(Mathf.Round(basePosition.x * 2) / 2, Mathf.Round(basePosition.y * 2) / 2);
            GameObject showingBox = Instantiate(rangeBox, tile, Quaternion.identity);
            rangeBoxes.Add(showingBox);
        }
    }
}
