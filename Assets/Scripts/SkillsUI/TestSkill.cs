using UnityEngine;

[CreateAssetMenu(fileName = "TestSkill", menuName = "Gameplay/Skills/Create New TestSkill")]
public class TestSkill : ScriptableObject, ISkill
{
    [SerializeField] private SkillInfo _info;
    public ISkillInfo Info => _info;

    public void Activate()
    {
        Debug.Log($"����� {Info.Title} �������������");
    }
}
public interface ISkill
{
    ISkillInfo Info { get; }

    void Activate();
}
