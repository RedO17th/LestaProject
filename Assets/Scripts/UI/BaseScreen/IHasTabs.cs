public interface IHasTabs : IScreen
{
    void InitializeTabs();
    void OpenTab(ITabScreen tab);
}
