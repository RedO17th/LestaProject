using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//[Note] ≈сли вынести инициализацию "диалоговых энкаунтеров" в данную подсистему,
//как функционал, то уже она будет решать, есть ли эти самые
//сущности внутри определенного quest'a и выполн€ть определенную логику

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