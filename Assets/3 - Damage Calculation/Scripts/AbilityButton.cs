using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityButton : MonoBehaviour
{
    [SerializeField] int _index;
    [SerializeField] Button _button;
    [SerializeField] TMP_Text _textKey;

    public event Action<int> onClick;

    void Awake()
    {
        _button.onClick.AddListener(() =>
        {
            onClick?.Invoke(_index);
        });
    }

    public async Awaitable EnterCooldown(float cooldownTime)
    {
        _button.interactable = false;
        _textKey.color = Color.gray;

        await Awaitable.WaitForSecondsAsync(cooldownTime, Application.exitCancellationToken);

        _button.interactable = true;
        _textKey.color = Color.white;
    }
}
