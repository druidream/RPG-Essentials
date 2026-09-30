using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Attribute
{
    [field: SerializeField] public int BaseValue { get; private set; }
    [field: SerializeField] public int FinalValue { get; private set; }
    [SerializeField] List<AttributeModifier> _modifiers = new List<AttributeModifier>();

    public Attribute(int baseValue)
    {
        BaseValue = baseValue;
        FinalValue = RecalculateFinalValue(BaseValue, _modifiers);
    }

    public void AddModifier(AttributeModifier modifier)
    {
        if (_modifiers.Contains(modifier)) return;

        _modifiers.Add(modifier);
        FinalValue = RecalculateFinalValue(BaseValue, _modifiers);
    }

    public void RemoveModifier(AttributeModifier modifier)
    {
        if (!_modifiers.Contains(modifier)) return;

        _modifiers.Remove(modifier);
        FinalValue = RecalculateFinalValue(BaseValue, _modifiers);
    }

    int RecalculateFinalValue(int baseValue, List<AttributeModifier> modifiers)
    {
        float calculatedValue = baseValue;

        foreach (AttributeModifier modifier in modifiers)
            if (modifier.Type == ModifierType.Flat)
                calculatedValue += modifier.Amount;

        float finalPercentage = 1f;
        foreach (AttributeModifier modifier in modifiers)
            if (modifier.Type == ModifierType.Percentage)
                finalPercentage += modifier.Amount / 100f;

        calculatedValue = calculatedValue * finalPercentage;

        return (int)calculatedValue;
    }
}
