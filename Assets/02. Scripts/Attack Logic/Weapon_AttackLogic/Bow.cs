using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Bow : WeaponAttack
{
    public GameObject rangeShower;

    public override void Attack(Vector2 direction)
    {
        CheckAttackRange(direction);
        ClearRangeBoxes();
    }

    public override void ShowAttackRange(Vector2 direction)
    {
        Vector2 position = (Vector2)transform.position + new Vector2(0f, -0.15f);
        RaycastHit2D hit = Physics2D.Raycast(position, direction, range, targetlayer);

        for (int i = 1; i <= range; i++)
        {
            Vector2 boxPosition = position + direction * i;
            GameObject boxPrefab;
            if (hit.collider != null && hit.distance >= i)
            {
                boxPrefab = rangeShower; 
            }
            else
            {
                boxPrefab = rangeBox; 
            }

            GameObject showingBox = Instantiate(boxPrefab, boxPosition, Quaternion.identity);
            rangeBoxes.Add(showingBox);

            if (hit.collider != null && hit.distance < i)
                break;
        }
    }
}
