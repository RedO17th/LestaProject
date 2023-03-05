using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIContainer : MonoBehaviour
{
    //[TODO] Refact
    [Header("Screens")]
    [SerializeField] private IngameScreen _HUDScreen = null;
    [SerializeField] private IngameScreen _inventoryScreen = null;
    [SerializeField] private IngameScreen _clipboardScreen = null;
    [SerializeField] private IngameScreen _skillsScreen = null;
    [SerializeField] private IngameScreen _pauseMenuScreen = null;
    [SerializeField] private IngameScreen _dialogueScreen = null;
    [SerializeField] private IngameScreen _settingsScreen = null;

    [Header("Journal")]
    [SerializeField] private JournalUI _activeQuestsJournal;
    [SerializeField] private JournalUI _completeQuestsJournal;
    [SerializeField] private JournalUI _diaryJournal;

    [Header("Quick Access Menu")]
    [SerializeField] private UIQuickAccessMenu _quickAccessMenu;
    [SerializeField] private UIQuickAccessMenu _quickAccessMenuhud;
    [SerializeField] private UIInventoryController _uiInventoryController;

    public IngameScreen HUDScreen => _HUDScreen;
    public IngameScreen InventoryScreen => _inventoryScreen;
    public IngameScreen ClipboardScreen => _clipboardScreen;
    public IngameScreen SkillsScreen => _skillsScreen;
    public IngameScreen PauseMenuScreen => _pauseMenuScreen;
    public IngameScreen DialogueScreen => _dialogueScreen;
    public IngameScreen SettingsScreen => _settingsScreen;

    public JournalUI ActiveQuestsJournal => _activeQuestsJournal;
    public JournalUI CompleteQuestsJournal => _completeQuestsJournal;
    public JournalUI DiaryJournal => _diaryJournal;

    public UIQuickAccessMenu QuickAccessMenu => _quickAccessMenu;
    public UIQuickAccessMenu QuickAccessMenuhud => _quickAccessMenuhud;
    public UIInventoryController UIInventoryController =>_uiInventoryController;
}
