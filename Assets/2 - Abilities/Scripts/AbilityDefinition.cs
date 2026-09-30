using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilityDefinition", menuName = "Scriptable Objects/AbilityDefinition")]
public class AbilityDefinition : ScriptableObject
{
    public string Name;
    public Sprite Icon;
    public List<AbilityLevelInfo> Levels;
}
