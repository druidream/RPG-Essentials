using System;
using UnityEngine;

[Serializable]
public class AbilityLevelInfo
{
    public int BaseMinDamage;
    public int BaseMaxDamage;
    [Range(0, 1)]
    public float BaseCriticalChance;
    public float BaseCooldownTime;
}
