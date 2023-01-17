using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������� ����� ��������, ������� ����� ���� �����-���� ������� ����������� �
//���������� Quest'e. ����� �������� ������ ��� ��������� � �����������.
//����� questLink ���������� ��������� � ���, ��� ������ ���� "���������".

//����� ����� ����������� ���������� - ����� �� �������, ���� ����� ����� ���� ����������,
//�� ������������ ��� � ��������������. 

public abstract class BaseQuestEntity : MonoBehaviour
{
    [Header("Quest settings")]
    [SerializeField] protected BaseQuestLink _questLink = null;

    public BaseQuestLink QuestLink => _questLink;

    public abstract void Activate();
    public abstract void Deactivate();
}

public class BaseConditionalQuestEntity : BaseQuestEntity
{
    public event Action OnComplete;

    public override void Activate() { }

    protected virtual bool CheckConditional() => true;

    public virtual void Complete()
    {
        if (CheckConditional())
        {
            OnComplete?.Invoke();

            _questLink.Complete();
        }
    }

    public override void Deactivate() { }
}
