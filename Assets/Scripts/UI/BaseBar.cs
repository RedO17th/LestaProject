using UnityEngine;

public abstract class BaseBar : MonoBehaviour, IBaseBar
{
    public abstract void ChangeValue(float changing);
}

public interface IBaseBar
{
    void ChangeValue(float changing);
}
