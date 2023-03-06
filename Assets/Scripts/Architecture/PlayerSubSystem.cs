using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SaveAndLoadModule;
using System;

public class PlayerSubSystem : BaseSubSystem, ILoaderObserver, ISaverObserver
{
    [SerializeField] private BasePlayer _player = null;

    public BasePlayer Player => _player;

    //[TODO] Remove
    private WalletOfPoints _walletOfPoints = null;
    private CharacteristicsContainer _characteristics = null;
    //..

    public override void Initialize()
    {
        InitializePlayer();
    }

    private void InitializePlayer()
    {
        _player.Initialize(this);
    }

    public override void Prepare()
    {
        var settingsSystem = ProjectSystem.GetSubSystem<SettingsSubSystem>();

        _characteristics = settingsSystem?.GetDataContainer<CharacteristicsContainer>();

        var saveLoadSystem = ProjectSystem.GetSubSystem<ISaveLoadSystem>();
            saveLoadSystem.AddObserver(this);
    }

    public T GetPlayerController<T>() where T : BasePlayerContoller
    {
        return _player.GetControllerBy<T>();
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

    #region SaveLoad part
    public void NotifyAboutLoad() => ProcessDataLoading();
    private void ProcessDataLoading()
    {
        Debug.Log($"PlayerSubSystem.ProcessDataLoading");
    }

    public void NotifyAboutSave() => ProcessDataSaving();
    private void ProcessDataSaving()
    {
        Debug.Log($"PlayerSubSystem.ProcessDataSaving");
    }
    #endregion
}
