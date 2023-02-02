using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogueResult : BaseDialogueResult
{
    protected override void ProcessInvoke()
    {
        var context = new TaskContext();
            context.SetCommand(TaskCommand.Complete);
            context.SetID(_encounter.Task.IDName);

        ProjectBus.Instance.SendSignalByContext(context);
    }
}
