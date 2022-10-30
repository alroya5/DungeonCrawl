using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public enum ItemType
    {
        BasicDagger,
        BattleAxe,
        Longbow,
        Sword,
        FireBomb,
        VenenousKnife,
        MoreStats,
        SmallShield,
        MediumShield,
        BigShield,
        NoShield
    }
    public static int GetCost(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.BasicDagger: return 10;
            case ItemType.BattleAxe: return 20;
            case ItemType.Longbow: return 30;
            case ItemType.Sword: return 40;
            case ItemType.FireBomb: return 50;
            case ItemType.VenenousKnife: return 5;
            case ItemType.MoreStats: return 100;
            case ItemType.SmallShield: return 25;
            case ItemType.MediumShield: return 50;
            case ItemType.BigShield: return 75;
            case ItemType.NoShield:return 0;
        }

    }
}
