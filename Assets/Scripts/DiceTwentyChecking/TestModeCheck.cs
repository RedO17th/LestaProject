using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestModeCheck : MonoBehaviour
{
    private CheckMode _checkMode;

    public CheckMode CheckMode
    {
        get
        {
            return _checkMode;
        }
        private set
        {
            _checkMode = value;
        }
    }

    public void SetCharacteristicMode()
    {
        CheckMode = CheckMode.Characteristics;
    }

    public void SetSkillMode()
    {
        CheckMode = CheckMode.Skill;
    }
}
