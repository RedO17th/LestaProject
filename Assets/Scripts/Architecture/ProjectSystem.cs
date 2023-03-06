using SaveAndLoadModule;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum GameStateType { None = -1, Menu, Pause, GamePlay, Exit }

public class ProjectSystem : MonoBehaviour
{
    [SerializeField] private GameStateType _standartGameState = GameStateType.None;

    [SerializeField] private List<BaseSubSystem> _subSystems;

    #region Singleton instance
    public static ProjectSystem Instance => _instance;

    private static ProjectSystem _instance = null;
    #endregion

    public event Action<GameStateType> OnGameStateChanged;

    private BaseGameState _currentGameState = null;
    private List<BaseGameState> _gameStates = null;

    //Awake period
    private void Awake()
    {
        InitializeSystem();

        InitializeGameStates();
        SetStandartGameState();
    }

    private void InitializeSystem()
    {
        if (_instance == null) _instance = this;
        else Destroy(gameObject);
    }
    private void InitializeGameStates()
    {
        _gameStates = new List<BaseGameState>()
        { 
            { new MenuGameState(this) },
            { new PauseGameState(this) },
            { new GamePlayGameState(this) },
            { new ExitGameState(this) }
        
        };
    }
    private void SetStandartGameState()
    {
        _currentGameState = GetGameStateBy(_standartGameState);
    }
    //..

    private BaseGameState GetGameStateBy(GameStateType type) 
    {
        BaseGameState result = null;

        foreach (var state in _gameStates)
        {
            if (state.Type == type)
            {
                result = state;
                break;
            }
        }

        return result;
    }

    public static T GetSubSystem<T>() where T : class
    {
        T system = null;

        foreach (var s in _instance._subSystems)
        {
            if (s is T)
            {
                system = s as T;
                break;
            }
        }

        return system;
    }

    private void Start() => StartScene();
    public void StartScene()
    {
        InitializeSubSystems();
        PrepareSubSystems();

        //LoadDataToSubSystems();

        StartSubSystems();
    }

    private void InitializeSubSystems()
    {
        foreach (var s in _subSystems)
            s.Initialize();
    }
    private void PrepareSubSystems()
    {
        foreach (var s in _subSystems)
            s.Prepare();
    }

    //private void LoadDataToSubSystems()
    //{
    //    foreach (var system in _subSystems)
    //    {
    //        if (system is ILoader loader)
    //        {
    //            loader.Load();
    //        }
    //    }
    //}

    private void StartSubSystems()
    {
        foreach (var system in _subSystems)
            system.StartSystem();
    }
    //..

    private void Update()
    {
        //ProcessingGameStates();


        //and more...
    }

    //[TODO] Сигнал о выключении всех систем...
    //..

    #region ProcessingGameStates
    private void ProcessingGameStates()
    {
        if (_currentGameState == null)
            return;

        var newtStateType = _currentGameState.Tick();

        if (newtStateType != GameStateType.None && newtStateType != _currentGameState.Type)
        {
            SwitchGameState(newtStateType);
        }
    }

    private void SwitchGameState(GameStateType type)
    {
        _currentGameState = GetGameStateBy(type);
        OnGameStateChanged?.Invoke(type);
    }
    #endregion
}

//[TODO]Transfer to personal files
public abstract class BaseGameState
{
    public GameStateType Type => _type;

    protected GameStateType _type = GameStateType.None;
    protected ProjectSystem _projectSystem = null;

    public BaseGameState(ProjectSystem system)
    {
        _projectSystem = system;
    }

    public abstract GameStateType Tick();
}

public class MenuGameState : BaseGameState
{
    public MenuGameState(ProjectSystem system) : base(system) 
    {
        _type = GameStateType.Menu;
    }

    public override GameStateType Tick()
    {
        //Debug.Log($"MenuGameState.Tick");

        //Заглушка
        return GameStateType.Menu;
    }
}

public class PauseGameState : BaseGameState
{
    public PauseGameState(ProjectSystem system) : base(system)
    {
        _type = GameStateType.Pause;
    }

    public override GameStateType Tick()
    {
        Debug.Log($"PauseGameState.Tick");

        //Заглушка
        return GameStateType.Pause;
    }
}

public class GamePlayGameState : BaseGameState
{
    public GamePlayGameState(ProjectSystem system) : base(system)
    {
        _type = GameStateType.GamePlay;
    }

    public override GameStateType Tick()
    {
        Debug.Log($"GamePlayGameState.Tick");

        //Заглушка
        return GameStateType.GamePlay;
    }
}

public class ExitGameState : BaseGameState
{
    public ExitGameState(ProjectSystem system) : base(system)
    {
        _type = GameStateType.Exit;
    }

    public override GameStateType Tick()
    {
        Debug.Log($"ExitGameState.Tick");

        //Заглушка
        return GameStateType.Exit;
    }
}
//..
