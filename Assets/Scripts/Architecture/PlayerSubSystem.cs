using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSubSystem : BaseSubSystem
{
    [SerializeField] private BasePlayer[] _players = null;

    private WalletOfPoints _walletOfPoints = null;

    private CharacteristicsContainer _characteristics = null;

    public override void Initialize(ProjectSystem system)
    {
        base.Initialize(system);

        InitializePlayers();

        //Test: При этом данное значение необходимо откуда либо брать...
        _walletOfPoints = new WalletOfPoints(100);
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

    #region Wallet part
    public void AddPoints(int points)
    {
        _walletOfPoints.Add(points);
    }

    #endregion

    #region Clear part
    public override void Clear()
    {
        ClearWallet();
    }

    private void ClearWallet()
    {
        _walletOfPoints.RemoveAll();
        _walletOfPoints = null;
    }
    #endregion
}
