using UnityEngine;

public class TabGroupUIController : BaseUIController
{
    [SerializeField] private TabButton[] _tabs = null;

    [SerializeField] private TabContent[] _pages = null;

    public void Start()
    {
        foreach (var tab in _tabs)
        {
            tab.Initialize();
            tab.Subscribe(HandleOnTabClicked);
        }

        //_tabs[0]?.onClick.Invoke();
    }

    public void HandleOnTabClicked(BaseButton sender)
    {
        var tabID = ((sender as TabButton).Data as TabButtonData).TabID;

        foreach (var page in _pages)
        {
            if (page.TabsID.Contains(tabID))
            {
                page.gameObject.SetActive(true);
            }
            else
            {
                page.gameObject.SetActive(false);
            }
        }

        foreach (var tab in _tabs)
        {
            if (tab == sender)
            {
                tab.SetActive();
            }
            else
            {
                tab.SetInactive();
            }
        }
    }
}
