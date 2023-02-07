using UnityEngine;
using TMPro;

public class PlayerInfoPanelUIController : BaseUIController
{
    [SerializeField] private BaseBar _healthBar = null;
    [SerializeField] private BaseBar _energyBar = null;
    [SerializeField] private BaseBar _experienceBar = null;
    [SerializeField] private TextMeshProUGUI _levelText;

    private HealthSign _playerHealthSystem = null;
    private EnergySign _playerEnergySystem = null;
    private Level _playerLevelSystem = null;

    public void OnEnable()
    {
      
    }

    private void Start()
    {
        var playerSubSystem = ProjectSystem.Instance.GetSubSystemByType(typeof(PlayerSubSystem)) as PlayerSubSystem;
        _playerHealthSystem = playerSubSystem.Player.Health;
        _playerEnergySystem = playerSubSystem.Player.Energy;
        _playerLevelSystem = playerSubSystem.Player.Level;

        SubscribeToEvents();
        PrepareSubordinates();
    }

    private void SubscribeToEvents()
    {
        _playerHealthSystem.OnValueChanged += HandleOnHealthChanged;
        _playerEnergySystem.OnValueChanged += HandleOnEnergyChanged;
        _playerLevelSystem.OnPointsChanged += HandleOnExperienceChanged;
        _playerLevelSystem.OnLevelChanged += HandleOnLevelChanged;
    }
    
    private void PrepareSubordinates()
    {
        _healthBar.SetValue(_playerHealthSystem.NormalizedValue);
        _energyBar.SetValue(_playerEnergySystem.NormalizedValue);
        _experienceBar.SetValue(_playerLevelSystem.NormalizedPoints);
        _levelText.text = _playerLevelSystem.CurrentLevel.ToString();
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

    public void OnDisable()
    {
        UnsubscribeFromEvents();
    }
    
    private void UnsubscribeFromEvents()
    {
        _playerHealthSystem.OnValueChanged -= HandleOnHealthChanged;
        _playerEnergySystem.OnValueChanged -= HandleOnEnergyChanged;
        _playerLevelSystem.OnPointsChanged -= HandleOnExperienceChanged;
        _playerLevelSystem.OnLevelChanged -= HandleOnLevelChanged;
    }
}
