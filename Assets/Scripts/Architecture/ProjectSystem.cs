using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum GameStateType { None = -1, Menu, Pause, GamePlay, Exit }

public enum SubSystemType { None = -1, UI, Sound, Settings, Military, Time }

public class ProjectSystem : MonoBehaviour
{
    [SerializeField] private GameStateType _standartGameState = GameStateType.None;

    [SerializeField] private List<BaseProjectSubSystem> _subsystems;

    #region Singleton instance
    public static ProjectSystem Instance => _instance;

    private static ProjectSystem _instance = null;
    #endregion

    public event Action<GameStateType> OnGameStateChanged;

    private BaseGameState _currentGameState = null;
    private List<BaseGameState> _gameStates = null;

    private void Awake()
    {
        InitializeSystem();

        InitializeGameStates();
        SetStandartGameState();

        InitializeSubSystems();
    }


    #region Initialize region
    private void InitializeSystem()
    {
        if (_instance == null) _instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
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
    private void InitializeSubSystems()
    {
        foreach (var s in _subsystems)
            s.Initialize(this);
    }
    #endregion

    private void SetStandartGameState()
    {
        _currentGameState = GetGameStateBy(_standartGameState);
    }

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

    public BaseProjectSubSystem GetSubSystemBy(SubSystemType type)
    {
        return _subsystems.Where(s => s.Type == type) as BaseProjectSubSystem;
    }

    private void Update()
    {
        ProcessingGameStates();


        //and more...
    }

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
        Debug.Log($"MenuGameState.Tick");

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
