using System;
using UnityEngine;


public interface IDistributionGroup
{
    event Action<IDistributionGroup> OnIncreseValueRequest;
    event Action<IDistributionGroup> OnDecreseValueRequest;
}

public class BaseDistributionButtonsGroup : MonoBehaviour, IDistributionGroup, IHaveButtons
{
    [SerializeField] protected BaseButtonWraper _decreaseButton = null;
    [SerializeField] protected BaseButtonWraper _increaseButton = null;

    public event Action<IDistributionGroup> OnIncreseValueRequest;
    public event Action<IDistributionGroup> OnDecreseValueRequest;

    public void HandleChangeAction()
    {
        throw new NotImplementedException();
    }

    public void OnEnable()
    {
        _decreaseButton = transform.Find("DecreaseButton").gameObject.GetComponent<BaseButtonWraper>();
        _increaseButton = transform.Find("IncreaseButton").gameObject.GetComponent<BaseButtonWraper>();
        SubscribeToButtonsEvents();
    }

    public void OnDisable()
    {
        UnsubscribeToButtonsEvents();
    }

    public void SubscribeToButtonsEvents()
    {
        _decreaseButton.OnButtonClicked += HandleOnButtonClicked;
        _increaseButton.OnButtonClicked += HandleOnButtonClicked;
    }

    public void UnsubscribeToButtonsEvents()
    {
        _decreaseButton.OnButtonClicked -= HandleOnButtonClicked;
        _increaseButton.OnButtonClicked -= HandleOnButtonClicked;
    }

    protected void HandleOnButtonClicked(IButtonWrapper clickedButton)
    {
        if (clickedButton == _increaseButton)
        {
            OnIncreseValueRequest?.Invoke(this);
        }

        if (clickedButton == _decreaseButton)
        {
            OnDecreseValueRequest?.Invoke(this);
        }
    }
}
