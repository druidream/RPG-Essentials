using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AbilityView : MonoBehaviour
{
    [SerializeField] Image _image;
    [SerializeField] TMP_Text _nameText;
    [SerializeField] TMP_Text _damageText;
    [SerializeField] TMP_Text _cooldownText;
    [SerializeField] TMP_Text _criticalChanceText;
    [SerializeField] TMP_Text _levelText;
    
    public void UpdateView(Ability ability)
    {
        _image.sprite = ability.Definition.Icon;
        _nameText.text = ability.Definition.Name;

        (int minDamage, int maxDamage) = ability.GetDamage();
        _damageText.text = $"Damage: {minDamage} - {maxDamage}";

        _cooldownText.text = $"Cooldown: {ability.GetCooldown()} s";

        float parsedCriticalChance = ability.GetCriticalChange() * 100;
        _criticalChanceText.text = $"Critical Chance: {parsedCriticalChance} %";

        _levelText.text = $"LV. {ability.Level}";
    }
}
