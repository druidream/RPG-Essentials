using UnityEngine;

public static class CombatUtils
{
    public static int CalculateDamage(int baseDamage, int attributePoints, bool isCritical)
    {
        float multiplier = 1 + (attributePoints / 10f); // 1 point = +1% damage
        float damage = Mathf.FloorToInt(baseDamage * multiplier);

        if (isCritical) 
            damage *= 2;

        return (int)damage;
    }
}
