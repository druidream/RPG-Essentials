using System;
using UnityEngine;

[Serializable]
public class ExperienceSystem
{
    [SerializeField] ExperienceTable _experienceTable;
    [SerializeField] int _currentLevel;
    [SerializeField] int _currentExp;

    public event Action<int, int, int> OnExperienceChanged;

    public ExperienceSystem(ExperienceTable experienceTable)
    {
        _experienceTable = experienceTable;
        _currentLevel = 1;
        _currentExp = 0;
    }

    public void AddExp(int experience)
    {
        if (_currentLevel >= _experienceTable.FromLevel.Count) return;

        _currentExp += experience;
        CheckLevelUp();

        bool isMaxLevel = _currentLevel >= _experienceTable.FromLevel.Count; 
        int experienceLevelLimit = isMaxLevel
            ? _experienceTable.FromLevel[_experienceTable.FromLevel.Count - 1]
            : _experienceTable.FromLevel[_currentLevel - 1];

        OnExperienceChanged?.Invoke(_currentLevel, _currentExp, experienceLevelLimit);
    }

    void CheckLevelUp()
    {
        while (_currentLevel < _experienceTable.FromLevel.Count && _currentExp >= _experienceTable.FromLevel[_currentLevel - 1])
        {
            _currentExp -= _experienceTable.FromLevel[_currentLevel - 1];
            _currentLevel++;
        }

        bool isMaxLevel = _currentLevel >= _experienceTable.FromLevel.Count; 
        if (isMaxLevel)
        {
            _currentExp = 0;
        }
    }
}
