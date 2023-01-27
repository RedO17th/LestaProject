using UnityEngine;

public class HUD_PlayerInfo_Controller : BaseUIController
{

    [SerializeField] private BaseBar _healthBar = null;
    [SerializeField] private BaseBar _energyBar = null;

    private HealthSign _playerHealthSystem = null;
    private EnergySign _playerEnergySystem = null;

    public override void Initialize(BaseWindow window)
    {
        base.Initialize(window);

        var playerSubSystem = ProjectSystem.Instance.GetSubSystemByType(typeof(PlayerSubSystem)) as PlayerSubSystem;
        _playerHealthSystem = playerSubSystem.Player.Health;
        _playerEnergySystem = playerSubSystem.Player.Energy;
    }

    public void OnEnable()
    {
        _playerHealthSystem.OnValueChanged += HandleOnHealthChanged;
        _playerEnergySystem.OnValueChanged += HandleOnEnergyChanged;
    }

    private float NormalizeChanging(int changing, int maxValue)
    {
        return (float)changing / maxValue;
    }

    private void HandleOnHealthChanged(int changing)
    {
        float normalChanging = NormalizeChanging(changing, _playerHealthSystem.MaxValue);
        _healthBar?.ChangeValue(normalChanging);
    }

    private void HandleOnEnergyChanged(int changing) 
    {
        float normalChanging = NormalizeChanging(changing, _playerEnergySystem.MaxValue);
        _energyBar?.ChangeValue(normalChanging);
    }

    public void OnDisable()
    {
        _playerHealthSystem.OnValueChanged -= HandleOnHealthChanged;
        _playerEnergySystem.OnValueChanged -= HandleOnEnergyChanged;
    }
}
