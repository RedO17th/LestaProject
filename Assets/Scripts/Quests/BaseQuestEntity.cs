using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Базовый класс сущности, который может быть каким-либо образом использован в
//конкретном Quest'e. Имеет основные методы для Активации и Деактивации.
//Через questLink происходит сообщение о том, что задача была "выполнена".

//Класс имеет минимальный функционал - класс не трогать, если нужен будет свой функционал,
//то унаследовать его и переопределить. 

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
