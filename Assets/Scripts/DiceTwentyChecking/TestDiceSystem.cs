using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestDiceSystem : MonoBehaviour
{
    [SerializeField] private DiceTwentySubSystem _diceSystem;

    [SerializeField] private InputField _difficult;

    [SerializeField] private Image _resultImage;

    [SerializeField] private TestModeCheck _mode;

    [SerializeField] private TMP_Dropdown[] _dropdowns;

    public void TestCheck()
    {
        var dropdown = _dropdowns[(int)_mode.CheckMode];
        
        int.TryParse(_difficult.text, out int difficult);
        
        bool result = false;

        switch (_mode.CheckMode)
        {
            case CheckMode.Characteristics:
                result = _diceSystem.Check((CharacterisicType)dropdown.value, difficult);
                break;
            case CheckMode.Skill:
                result = _diceSystem.Check((SkillType)dropdown.value, difficult);
                break;
        }

        _resultImage.color = result ? Color.green : Color.red;
    }
}
