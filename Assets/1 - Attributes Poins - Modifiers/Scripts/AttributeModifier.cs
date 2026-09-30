using UnityEngine;

public enum ModifierType
{
    Flat,
    Percentage
}

public class AttributeModifier
{
    public ModifierType Type;
    public int Amount;

    public AttributeModifier(ModifierType type, int amount)
    {
        Type = type;
        Amount = amount;
    }
}
