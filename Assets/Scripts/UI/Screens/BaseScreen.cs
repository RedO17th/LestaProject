using UnityEngine;

public interface IScreen
{
    IScreenID GetID { get; }
    void ShowScreen();
    void HideScreen();
}

public interface IScreenID
{
    object getID();
}

public abstract class BaseScreen : MonoBehaviour, IScreen
{
    [SerializeField] private ScreenType _screenType = ScreenType.None;
    public IScreenID GetID => _screenID;
    private IScreenID _screenID = null;
    public void Start() => _screenID = GetComponent<IScreenID>();
    public void ShowScreen() => gameObject.SetActive(true);
    public void HideScreen() => gameObject.SetActive(false);

}

public enum ScreenType { None = -1, MainMenu, Ingame}

public class IngameID : MonoBehaviour, IScreenID
{
    enum IngameIDEnum { None = -1, First, Second }

    [SerializeField] private IngameIDEnum _id = IngameIDEnum.None;

    public object getID()
    {
        return _id;
    }
}

