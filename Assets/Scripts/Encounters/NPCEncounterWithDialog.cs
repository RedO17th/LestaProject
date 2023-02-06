public class NPCEncounterWithDialog : EncounterWithDialog
{
    public bool TaskIsExist => _task != null;

    public BaseDialogController DialogController => _dialogController;

    protected BaseInteractionsController _interactionHandler = null;

    protected DialogSubSystem _dialogSubSystem = null;
    protected BaseDialogController _dialogController = null;
}
