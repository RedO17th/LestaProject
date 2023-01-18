using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

//[ForMe] При необходимости "накидать" интерфейсов
public interface IDialogable
{
    void Initialize(Component manager);
}

public class Dog : Encounter, IDialogable
{
    //[ForMe] Может сие вынести в отдельный Интерфейс
    [Space]
    [SerializeField] private QuestAndDialogsContaner _dialogContaner = null;

    private DialogSubSystem _dialogSystem = null;
    private BaseDialogController _dialogController = null;
    //...

    public void Initialize(Component manager)
    {
        if (manager is DialogSubSystem system)
            _dialogSystem = system;
    }

    public override void Activate()
    {
        base.Activate();

        if (_dialogSystem)
        { 
            _dialogController = new BaseDialogController(_dialogSystem);
            _dialogController.SetDialogContainer(_dialogContaner);            
        }
    }

    public override void Deactivate()
    {
        base.Deactivate();

        //_dialogController.Clear();
        //_dialogController = null;
    }
}
