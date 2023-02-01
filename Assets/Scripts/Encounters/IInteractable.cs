using System.Collections.Generic;

public interface IInteractable
{
    void Interact();
}

public class BaseInteractionsController : IInteractable
{
    protected IEncounter _encounter = null;

    protected List<BaseInteractionMode> _interactions = null;

    public BaseInteractionsController(IEncounter encounter)
    {
        _encounter = encounter;
        _interactions = new List<BaseInteractionMode>();
    }

    public virtual void InitializeInteractionModes() { }

    public virtual void Interact() 
    {
        var mode = GetInteractionMode();
            mode.Execute();
    }

    protected virtual BaseInteractionMode GetInteractionMode()
    {
        BaseInteractionMode mode = null;

        foreach (var interaction in _interactions)
        {
            if (interaction.CheckConditionForExecution())
            {
                mode = interaction;
            }
        }

        return mode;
    }
}

public abstract class BaseInteractionMode
{
    protected IEncounter _encounter = null;

    public BaseInteractionMode(IEncounter encounter) { _encounter = encounter; }

    public virtual bool CheckConditionForExecution() => false;
    public abstract void Execute();
}

public abstract class BaseSimpleInteractionMode : BaseInteractionMode
{
    public BaseSimpleInteractionMode(IEncounter encounter) : base(encounter) { }

    public override bool CheckConditionForExecution()
    {
        return base.CheckConditionForExecution();
    }
    public override void Execute() { }
}

public abstract class BaseTaskInteractionMode : BaseInteractionMode
{
    public BaseTaskInteractionMode(IEncounter encounter) : base(encounter) { }
    public override bool CheckConditionForExecution()
    {
        return base.CheckConditionForExecution();
    }
    public override void Execute() { }
}

