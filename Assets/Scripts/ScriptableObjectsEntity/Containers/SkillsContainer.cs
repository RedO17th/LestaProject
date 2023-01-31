using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skills", menuName = "ScriptableObjects/Container/Skills", order = 3)]
public class SkillsContainer : BaseDataContainer
{
    [SerializeField] private List<BaseSkill> _skills;

    public BaseSkill GetSkillByType(SkillType type)
    {
        return _skills.Find(x => x.Type.Equals(type));
    }

    public SkillType GetSkillTypeByName(string name)
    {
        return _skills.Find(x => x.Type.ToString().ToLower().Equals(name.ToLower())).Type;
    }
}
