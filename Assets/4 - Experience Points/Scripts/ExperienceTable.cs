using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Experience Table", menuName = "Scriptable Objects/Experience Table")]
public class ExperienceTable : ScriptableObject
{
    public List<int> FromLevel;
}
