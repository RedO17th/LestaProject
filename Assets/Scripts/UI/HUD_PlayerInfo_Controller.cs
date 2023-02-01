using UnityEngine;
using TMPro;

public class HUD_PlayerInfo_Controller : BaseUIController
{

    [SerializeField] private BaseBar _healthBar = null;
    [SerializeField] private BaseBar _energyBar = null;
    [SerializeField] private BaseBar _experienceBar = null;

    [SerializeField] private TextMeshProUGUI _levelText;

    private HealthSign _playerHealthSystem = null;
    private EnergySign _playerEnergySystem = null;

    private TestPlayer _testPlayer;

    public override void Initialize(BaseWindow window)
    {
        base.Initialize(window);

        var playerSubSystem = ProjectSystem.Instance.GetSubSystemByType(typeof(PlayerSubSystem)) as PlayerSubSystem;
        _playerHealthSystem = playerSubSystem.Player.Health;
        _playerEnergySystem = playerSubSystem.Player.Energy;
        //Подписывается на ивенты плеера и изменяет показатели по вызову ивентов
    }
    private void Start()
    {
        TestInit();
    }

    public void TestInit()
    {
        _testPlayer = TestPlayer.Instance;
        _testPlayer.OnHealthChanged += HandleOnHealthChanged;
        _testPlayer.OnEnergyChanged += HandleOnEnergyChanged;
        _testPlayer.OnExpChanged += HandleOnExperienceChanged;
        _testPlayer.OnLevelChanged += HandleOnLevelChanged;

        _healthBar.SetMaxValue(_testPlayer.MaxHealth);
        _energyBar.SetMaxValue(_testPlayer.MaxEnergy);
        _experienceBar.SetMaxValue(_testPlayer.MaxExperience);
    }

    public void OnEnable()
    {
        _playerHealthSystem.OnValueChanged += HandleOnHealthChanged;
        _playerEnergySystem.OnValueChanged += HandleOnEnergyChanged;
    }

    private void HandleOnHealthChanged(int value)
    {
        _healthBar?.SetValue(value);
    }

    private void HandleOnEnergyChanged(int value) 
    {
        _energyBar?.SetValue(value);
    }

    private void HandleOnExperienceChanged(int value)
    {
        _experienceBar.SetValue(value);
    }

    private void HandleOnLevelChanged(int value)
    {
        _levelText.text = value.ToString();
    }


    public void OnPortraitClick()
    {
        Debug.Log("Кликнули на портрет");
    }

    public void OnDisable()
    {
        _playerHealthSystem.OnValueChanged -= HandleOnHealthChanged;
        _playerEnergySystem.OnValueChanged -= HandleOnEnergyChanged;
    }
}
