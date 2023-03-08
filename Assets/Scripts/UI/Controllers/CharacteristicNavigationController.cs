using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacteristicNavigationController : MonoBehaviour
{
    [SerializeField] private CommonButton _backButton = null;
    [SerializeField] private CommonButton _nextButton = null;

    public void Start()
    {
        SubscribeButton();
    }

    private void SubscribeButton()
    {
        _backButton.Subscribe(BackToMainMenu);
        _nextButton.Subscribe(OpenAbilitiesSettings);

    }


    private void OpenAbilitiesSettings(OLDBaseButton button)
    {
        Debug.Log("далее");
    }


    private void BackToMainMenu(OLDBaseButton button)
    {
        Debug.Log("назад");
    }
}
