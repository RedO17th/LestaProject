using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : BaseDialogue
{
    public override void ProcessCommandViaTag(string tag)
    {
        Debug.Log($"Dialogue.ProcessCommandViaTag: tag is {tag} ");
    }
}

public class Map
{
    private BaseQuestTask _task1;
    private BaseQuestTask _task2;
    private BaseQuestTask _task3;
    private BaseQuestTask _task4;
    private BaseQuestTask _task5;

    List<BaseQuestTask> _tasks = new List<BaseQuestTask>();

    public void Initialize()
    {
        _task1 = new BaseQuestTask();
        _tasks.Add(_task1);

        _task2 = new BaseQuestTask();
        _tasks.Add(_task2);

        _task3 = new BaseQuestTask();
        _tasks.Add(_task3);

        _task4 = new BaseQuestTask();
        _tasks.Add(_task4);

        _task5 = new BaseQuestTask();
        _tasks.Add(_task5);
    }

    public void GetTask(string name)
    {
        foreach (var item in _tasks)
        {
            //item.name == name => Return item;
        }
    }
}