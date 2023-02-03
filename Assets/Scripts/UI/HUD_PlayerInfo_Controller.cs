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
    private Level _playerLevelSystem = null;

    public override void Initialize(BaseWindow window)
    {
        base.Initialize(window);

        var playerSubSystem = ProjectSystem.Instance.GetSubSystemByType(typeof(PlayerSubSystem)) as PlayerSubSystem;
        _playerHealthSystem = playerSubSystem.Player.Health;
        _playerEnergySystem = playerSubSystem.Player.Energy;
        _playerLevelSystem = playerSubSystem.Player.Level;
        //Подписывается на ивенты плеера и изменяет показатели по вызову ивентов
    }

    public void OnEnable()
    {
        SubscribeToEvents();
        PrepareBars();
    }


    private void SubscribeToEvents()
    {
        _playerHealthSystem.OnValueChanged += HandleOnHealthChanged;
        _playerEnergySystem.OnValueChanged += HandleOnEnergyChanged;
        _playerLevelSystem.OnPointsChanged += HandleOnExperienceChanged;
        _playerLevelSystem.OnLevelChanged += HandleOnLevelChanged;
    }

    private void UnsubscribeFromEvents()
    {
        _playerHealthSystem.OnValueChanged -= HandleOnHealthChanged;
        _playerEnergySystem.OnValueChanged -= HandleOnEnergyChanged;
        _playerLevelSystem.OnPointsChanged -= HandleOnExperienceChanged;
        _playerLevelSystem.OnLevelChanged -= HandleOnLevelChanged;
    }

    
    private void PrepareBars()
    {
        _healthBar.SetValue(_playerHealthSystem.NormalizedValue);
        _energyBar.SetValue(_playerEnergySystem.NormalizedValue);
        _experienceBar.SetValue(_playerLevelSystem.NormalizedPoints);
    }

    private void HandleOnHealthChanged(int value)
    {
        _healthBar?.SetValue(_playerHealthSystem.NormalizedValue);
    }

    private void HandleOnEnergyChanged(int value) 
    {
        _energyBar?.SetValue(_playerEnergySystem.NormalizedValue);
    }

    private void HandleOnExperienceChanged(int value)
    {
        _experienceBar.SetValue(_playerLevelSystem.NormalizedPoints);
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
        UnsubscribeFromEvents();
    }
}
