using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSubSystem : BaseSubSystem
{
    [SerializeField] private BasePlayer[] _players = null;

    private CharacteristicsContainer _characteristics = null;

    public override void Initialize(ProjectSystem system)
    {
        base.Initialize(system);

        InitializePlayers();
    }

    private void InitializePlayers()
    {
        foreach (var player in _players)
            player.Initialize(this);
    }

    public override void Prepare()
    {
        var settingsSystem = _projectSystem.GetSubSystemBy(typeof(SettingsSubSystem)) as SettingsSubSystem;

        _characteristics = settingsSystem?.GetDataContainerByType(typeof(CharacteristicsContainer)) as CharacteristicsContainer;
    }

    #region Characteristics part
    public BaseCharacteristic GetCharacteristicByType(CharacterisicType type)
    {
        return _characteristics.GetCharacteristicByType(type);
    }
    #endregion
}
