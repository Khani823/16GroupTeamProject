using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameDate", menuName = "Data/GameData", order = 1)]
public class GameData : ScriptableObject
{
    public ItemData[] myItems;
}
