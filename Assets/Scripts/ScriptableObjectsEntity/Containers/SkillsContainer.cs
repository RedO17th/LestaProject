using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skills", menuName = "ScriptableObjects/Container/Skills", order = 3)]
public class SkillsContainer : BaseDataContainer
{
    [SerializeField] private BaseSkill[] _skills;

    public BaseSkill GetSkillByType(SkillType skillType)
    {
        BaseSkill skill = null;

        foreach(var skillItem in _skills)
        {
            if (skillItem.Type == skillType)
            {
                skill = skillItem;
                break;
            }
        }

        return skill;
    }
}
