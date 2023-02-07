using UnityEngine;

[CreateAssetMenu(fileName = "SkillInfo", menuName = "Gameplay/Skills/Create New SkillInfo")]
public class SkillInfo : ScriptableObject, ISkillInfo
{
    [SerializeField] private string _id;
    [SerializeField] private string _title;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _spriteIcon;

    public string ID => _id;
    public string Title => _title;

    public string Description => _description;

    public Sprite SpriteIcon => _spriteIcon;
}
