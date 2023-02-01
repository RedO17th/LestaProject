using UnityEngine.InputSystem;

public interface IBindableSlot
{
    public void OnBindingUse(InputAction.CallbackContext context);
}
