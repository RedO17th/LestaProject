using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSubSystem : BaseSubSystem
{
    [SerializeField] private BasePlayer _player = null;

    public BasePlayer Player => _player;

    private WalletOfPoints _walletOfPoints = null;
    private CharacteristicsContainer _characteristics = null;

    public override void Initialize(ProjectSystem system)
    {
        base.Initialize(system);

        InitializePlayers();

        //Test: ��� ���� ������ �������� ���������� ������ ���� �����...
        _walletOfPoints = new WalletOfPoints(100);
    }

    private void InitializePlayers()
    {
        _player.Initialize(this);
    }

    public override void Prepare()
    {
        var settingsSystem = _projectSystem.GetSubSystemByType(typeof(SettingsSubSystem)) as SettingsSubSystem;

        _characteristics = settingsSystem?.GetDataContainerByType(typeof(CharacteristicsContainer)) as CharacteristicsContainer;
    }

    #region Characteristics part
    public BaseCharacteristic GetCharacteristicByType(CharacterisicType type)
    {
        return _characteristics.GetCharacteristicByType(type);
    }
    #endregion


    #region Wallet part
    [ContextMenu("TestAddPoints")]
    public void TestAddPoints()
    {
        AddPoints(10);
    }

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
