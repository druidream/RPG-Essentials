using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DistributePoints : MonoBehaviour
{
    [SerializeField] int _str;
    [SerializeField] int _pointsLeft;
    [SerializeField] Button _buttonIncreaseSTR;
    [SerializeField] TMP_Text _textSTRPoints;
    [SerializeField] TMP_Text _textPointsLeft;

    void Awake()
    {
        _buttonIncreaseSTR.onClick.AddListener(IncreaseSTR);
    }

    void IncreaseSTR()
    {
        if (_pointsLeft <= 0) return;

        _pointsLeft--;
        _str++;

        _textPointsLeft.text = _pointsLeft.ToString();
        _textSTRPoints.text = _str.ToString();
    }
}
