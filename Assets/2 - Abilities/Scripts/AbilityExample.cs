using UnityEngine;

public class AbilityExample : MonoBehaviour
{
    [SerializeField] AbilityDefinition _meteorStormDefinition;
    [SerializeField] Ability _meteorStorm;
    [SerializeField] AbilityView _view;

    void Awake()
    {
        _meteorStorm = new Ability(_meteorStormDefinition);
        _view.UpdateView(_meteorStorm);
    }

    public void LevelUpMeteorStorm()
    {
        _meteorStorm.LevelUp();
        _view.UpdateView(_meteorStorm);
    }

    public void ResetMeteorStorm()
    {
        _meteorStorm.Reset();
        _view.UpdateView(_meteorStorm);
    }
}
