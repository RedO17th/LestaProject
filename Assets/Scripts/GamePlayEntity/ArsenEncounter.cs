using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArsenEncounter : Encounter//, ITalkable
{
    //������ ���������� ����� ���� ������, ��� ������ ��������� ������ -
    // - ���� �����������
    private BaseDialogController _dialogController = null;

    private DialogSubSystem _dialogSubSystem = null;

    private void Start()
    {
        _dialogController = GetComponent<BaseDialogController>();

        _dialogSubSystem = ProjectSystem.Instance.GetSubSystemByType(typeof(DialogSubSystem)) as DialogSubSystem;

        InitializeDialogable(_dialogSubSystem);
    }

    public void InitializeDialogable(DialogSubSystem system)
    {
        _dialogController.Initialize(system);
    }
    //public void SetDialog(BaseDialog dialog)
    //{
    //    _dialogController.SetDialog(dialog);
    //}


    public override void Activate()
    {
        base.Activate();
    }

    //� �������������� ����� ���� ������ �����-�� ����� ��������?
    public override void Interact()
    {
        Debug.Log($"Arsen.Interact");

        _pointer.Disable();

        //_questLink.Complete();
        Talk();
    }

    public void Talk()
    {
        _dialogController.ActivateDialog();
    }

    public override void Deactivate()
    {
        base.Deactivate();
    }
}
