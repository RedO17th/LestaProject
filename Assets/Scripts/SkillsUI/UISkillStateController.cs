using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISkillStateController : MonoBehaviour
{
    private SkillSlot[] _skillSlots;
    private SkillSlotState[] _skillSlotsStates;

    private void Start()
    {
        _skillSlots = GetComponentsInChildren<SkillSlot>();
        _skillSlotsStates = GetSkillSlotsStates(_skillSlots);
    }

    private SkillSlotState[] GetSkillSlotsStates(SkillSlot[] skillSlots)
    {
        SkillSlotState[] skillSlotsStates = new SkillSlotState[skillSlots.Length];

        for (int i = 0; i < skillSlots.Length; i++)
        {
            skillSlotsStates[i] = skillSlots[i].State;
        }
        return skillSlotsStates;
    }

    public void SaveSkillStatesToGameData()
    {
        _skillSlotsStates = GetSkillSlotsStates(_skillSlots);

        UISkillStatesData skillStatesData = new UISkillStatesData(_skillSlotsStates);
        GameData.Instance.AddUISkillStatesData(skillStatesData);
    }

    public void LoadSkillStatesFromGameData()
    {
        _skillSlotsStates = GameData.Instance.UISkillStatesData.SkillSlotStates;

        for (int i = 0; i < _skillSlots.Length; i++)
        {
            _skillSlots[i].State = _skillSlotsStates[i];
            _skillSlots[i].Refresh();
        }
    }
}

[System.Serializable]
public class UISkillStatesData
{
    public SkillSlotState[] SkillSlotStates;

    public UISkillStatesData(SkillSlotState[] skillSlotStates)
    {
        SkillSlotStates = skillSlotStates;
    }
}


