using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SaveAndLoadModule;
using System;

public class PlayerSubSystem : BaseSubSystem, ILoaderObserver, ISaverObserver
{
    [SerializeField] private BasePlayer _player = null;

    public BasePlayer Player => _player;

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
        var saveLoadSystem = ProjectSystem.GetSubSystem<ISaveLoadSystem>();
            saveLoadSystem.AddObserver(this);
    }

    public T GetPlayerController<T>() where T : BasePlayerContoller
    {
        return _player.GetControllerBy<T>();
    }

    #region Clear part
    public override void Clear() { }

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
