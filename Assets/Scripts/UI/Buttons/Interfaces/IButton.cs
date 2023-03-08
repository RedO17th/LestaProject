using UnityEngine.Events;

public interface IButton
{
    void Subscribe(UnityAction<OLDBaseButton> listener);
}
