using UnityEngine;

public class TabGroupUIController : BaseUIController
{
    [SerializeField] private TabButton[] _tabsHeads = null;

    [SerializeField] private TabPage[] _tabsPages = null;

    public void Start()
    {
        foreach (var tab in _tabsHeads)
        {
            tab.Initialize();
            tab.Subscribe(OpenTab);
        }

        OpenTab(_tabsHeads[0]);
    }

    public void OpenTab(BaseButton sender)
    {
        var tabID = ((sender as TabButton).Data as TabButtonData).TabID;

        foreach (var page in _tabsPages)
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

        foreach (var tab in _tabsHeads)
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
