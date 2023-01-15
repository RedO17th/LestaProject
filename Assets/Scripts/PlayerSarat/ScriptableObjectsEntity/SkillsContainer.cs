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

    public override List<string> GetAllNames()
    {
        List<string> names = new List<string>();

        for(int i = 0; i < _skills.Length; i++)
            names.Add(_skills[i].Name);

        return names;
    }
}
