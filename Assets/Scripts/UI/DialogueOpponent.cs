using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueOpponent : MonoBehaviour
{
    [SerializeField] private Image _opponentSprite = null;

    private float _minValue = 0f;
    private float _maxValue = 0f;

    public void Initialize(DialogueSceneController controller)
    {
        _minValue = controller.MinHighlightValue;
        _maxValue = controller.MaxHighlightValue;
    }

    public void SetSprite(Sprite icon)
    {
        _opponentSprite.sprite = icon;
    }

    public void HighLight()
    {
        _opponentSprite.color = new Color(_maxValue, _maxValue, _maxValue);
    }

    public void UnhighLight()
    {
        _opponentSprite.color = new Color(_minValue, _minValue, _minValue);
    }
}
