using System;
using UnityEngine;

public class ExperienceExample : MonoBehaviour
{
    [SerializeField] ExperienceTable _experienceTable;
    [SerializeField] ExperienceSystem _experienceSystem;
    [SerializeField] ExperienceBar _experienceBar;

    void Awake()
    {
        _experienceSystem = new ExperienceSystem(_experienceTable);
        _experienceSystem.OnExperienceChanged += OnExperienceChanged;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _experienceSystem.AddExp(2);
        }
    }

    public void OnButton1EXP()
    {
        _experienceSystem.AddExp(1);
    }

    public void OnButton2EXP()
    {
        _experienceSystem.AddExp(2);
    }

    public void OnButton25EXP()
    {
        _experienceSystem.AddExp(25);
    }

    void OnExperienceChanged(int level, int currentExp, int maxExp)
    {
        _experienceBar.SetExperience(level, currentExp, maxExp);
    }
}
