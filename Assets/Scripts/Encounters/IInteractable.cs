
using System.Collections.Generic;

public enum InteractionMode { None = -1, Dialog, Info, Some }

public interface IInteractable
{
    void Interact();
}

public class BaseInteractionController : IInteractable
{
    protected InteractionMode _mode = InteractionMode.None;

    protected IEncounter _encounter = null;

    protected List<BaseInteractionHandler> _handlers;

    public BaseInteractionController(IEncounter encounter)
    {
        _encounter = encounter;

        _handlers = new List<BaseInteractionHandler>();
    }

    public virtual void InitializeInteractionHandlers()
    { 
        if(_encounter is IDialogableEncounter encounter)
            _handlers.Add(new DialogInteractionHandler(encounter));

        //and others type...
    }

    public virtual void Interact() 
    {
        CheckInteractonMode();
    }

    //Проверяется режим взаимодействия
    protected virtual void CheckInteractonMode() { }

    //И выполняются соответствующие инструкции
    protected virtual void PerformInteraction() { }
    protected virtual void PerformStandardInteraction() { }
}

public class BaseInteractionHandler
{
    protected IEncounter _encounter = null;
    public BaseInteractionHandler(IEncounter encounter)
    {
        _encounter = encounter;
    }
}

public class DialogInteractionHandler : BaseInteractionHandler
{
    public DialogInteractionHandler(IEncounter encounter) : base(encounter) { }
}

