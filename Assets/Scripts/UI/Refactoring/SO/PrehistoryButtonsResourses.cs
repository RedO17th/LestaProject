using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "PrehistoryButtons", menuName = "ScriptableObjects/UIResourses/PrehistoryButtons", order = 1)]
public class PrehistoryButtonsResourses : BaseUIResourse
{
    [Header("SO ����������� ��������")]
    public PrehistoryButtonCommonResorses CommonSprites;
    [Space(15)]

    [Header("SO �����������")]
    public List<ConcretePrehistory> Prehitosies;
}
