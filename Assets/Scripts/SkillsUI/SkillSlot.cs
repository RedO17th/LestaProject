using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public enum SkillSlotState
{
    CLOSED,
    OPENED,
    ACTIVATED
}

public class SkillSlot : MonoBehaviour
{
    public SkillSlotState State;
    [SerializeField] private TestSkill _skill;

    [Space]
    [SerializeField] private Image _image;
    [SerializeField] private Button _button;

    [Space]
    [SerializeField] private SkillSlot[] _childrenSlots;

    private void Start()
    {
        if (_skill == null)
            Debug.Log("Ќе задан скилл в слоте");

        _image.sprite = _skill.Info.SpriteIcon;

        Refresh();
    }

    public void Refresh()
    {
        switch(State)
        {
            case SkillSlotState.CLOSED:

                CloseSlot();
                break;
            
            case SkillSlotState.OPENED:

                OpenSlot();
                break;

            case SkillSlotState.ACTIVATED:
                
                ActivateSlot();
                break;
        }       
    }

    private void CloseSlot()
    {
        State = SkillSlotState.CLOSED;
        _button.enabled = false;
        _image.color = Color.gray;
    }

    public void OpenSlot()
    {
        State = SkillSlotState.OPENED;
        _button.enabled = true;
        _image.color = Color.white;
    }

    private void ActivateSlot()
    {
        State = SkillSlotState.ACTIVATED;
        _button.enabled = false;
        _image.color = Color.white;
        //Ёффект
    }

    private void OpenChildrenSlots()
    {
        foreach (var slot in _childrenSlots)
        {
            slot.OpenSlot();
        }
    }

    public void ActivateSkill()
    {
        //if (!TestPlayer.Instance.SkillPoints.TryToRemoveSkillPoint())
            //return;

        _skill.Activate();

        ActivateSlot();
        OpenChildrenSlots();
    }
}


