public interface IToggledButtonWrapper : IButtonWrapper
{
    void SetActive();
    void SetInactive();
}


public abstract class BaseToggledButtonWrapper : BaseButtonWraper, IToggledButton
{
    public abstract void SetActive();

    public abstract void SetInactive();
}