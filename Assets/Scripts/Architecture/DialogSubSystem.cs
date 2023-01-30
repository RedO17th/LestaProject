using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//[Note] ���� ������� ������������� "���������� �����������" � ������ ����������,
//��� ����������, �� ��� ��� ����� ������, ���� �� ��� �����
//�������� ������ ������������� quest'a � ��������� ������������ ������

public class DialogSubSystem : BaseSubSystem
{
    private QuestSubSystem _questSubSystem = null;

    public override void Initialize(ProjectSystem system)
    {
        base.Initialize(system);
    }
    public override void Prepare()
    {
        _questSubSystem = _projectSystem.GetSubSystemByType(typeof(QuestSubSystem)) as QuestSubSystem;
    }

    public override void StartSystem() { }

    public override void Clear()
    {
        _questSubSystem = null;
    }
}