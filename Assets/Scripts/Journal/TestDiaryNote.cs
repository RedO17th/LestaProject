using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TestDiaryNote", menuName = "Gameplay/Journal/Create New TestDiaryNote")]
public class TestDiaryNote : ScriptableObject, INote
{
    [SerializeField] private string _id;
    [SerializeField] private string _title;
    [SerializeField] private string _description;
    public string Id => _id;

    public string Header => _title;

    public string Content => _description;

}
