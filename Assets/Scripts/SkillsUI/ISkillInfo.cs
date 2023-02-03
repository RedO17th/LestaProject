using UnityEngine;

public interface ISkillInfo
{
    string ID { get; }
    string Title { get; }
    string Description { get; }
    Sprite SpriteIcon { get; }
}
