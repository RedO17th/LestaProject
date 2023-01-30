using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Encounter
{
    protected override void Awake() { }

    private void OnEnable()
    {
        PrepareTriggerVolume();
    }
    private void OnDisable()
    {
        ClearTriggerVolume();
    }

    //public override void InitializeDialog()
    //{
    //    Debug.Log($"Dog.InitializeDialog");

    //    _dialog = "Some dialog";
    //}

    public override void Activate() { }

    public override void Interact()
    {
        Debug.Log($"Dog.Interact");

        _pointer.Disable();

        StartCoroutine(DialogTimer());
    }

    public override void Deactivate()
    {
        base.Deactivate();
    }

    //[Test]

    private IEnumerator DialogTimer()
    {
        yield return new WaitForSeconds(3f);

        if (_task != null)
        {
            var context = new TaskContext();
                context.SetCommand(TaskCommand.Complete);
                context.SetID(_task.IDName);

            ProjectBus.Instance.SendSignalByContext(context);
        }
    }
}
//[ForMe]
//����� ��������� � ������� ����� ��� DialogByQuestTask (DialogByTask) - 
//� ��� ����������� ��� ���� ������� � ��� idname, 
//�� ������� InitializeDialog �� IDialogable �������� ���� ���� �������
//� ���������������� ��...

