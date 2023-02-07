using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TestQuest", menuName = "Gameplay/Journal/Create New TestQuest")]
public class TestQuestForJournal : ScriptableObject, IQuestNote
{
    [SerializeField] private string _id;
    [SerializeField] private string _title;
    [SerializeField] private string _description;
    [SerializeField] private Reward _reward;

    public string Id => _id;

    public string Header => _title;

    public string Content => _description;

    public Reward Reward => _reward;
}
