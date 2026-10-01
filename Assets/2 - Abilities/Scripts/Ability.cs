using System;
using Mono.Cecil.Cil;
using UnityEngine;

[Serializable]
public class Ability
{
    [field: SerializeField] public int Level { get; set; }
    [field: SerializeField] public AbilityDefinition Definition { get; set; }
    [field: SerializeField] public bool IsInCooldown { get; set; }

    AbilityLevelInfo CurrentLevel => Definition.Levels[Level - 1];

    public Ability(AbilityDefinition definition)
    {
        Definition = definition;
        Level = 1;
    }

    public void LevelUp()
    {
        if (Level < Definition.Levels.Count)
            Level++;
    }

    public void Reset()
    {
        Level = 1;
    }

    struct GetDamageReturn
    {
        public int min;
        public int max;
    }

    public (int, int) GetDamage()
    {
        return (CurrentLevel.BaseMinDamage, CurrentLevel.BaseMaxDamage);
    }

    public float GetCriticalChange()
    {
        return CurrentLevel.BaseCriticalChance;
    }

    public float GetCooldown()
    {
        return CurrentLevel.BaseCooldownTime;
    }

    public async Awaitable StartCooldown()
    {
        IsInCooldown = true;
        await Awaitable.WaitForSecondsAsync(GetCooldown(), Application.exitCancellationToken);
        IsInCooldown = false;
    }
}
