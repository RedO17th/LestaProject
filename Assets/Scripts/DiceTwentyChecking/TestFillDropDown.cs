using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TestFillDropDown : MonoBehaviour
{
    [SerializeField] private BaseDataContainer _source;

    public int SelectItem
    {
        get;
        private set;
    }

    private void Awake()
    {
        var options = GetComponent<TMP_Dropdown>().options;

        var items = _source.GetAllNames();

        for (int i = 0; i < items.Count; i++)
            options.Add(new TMP_Dropdown.OptionData(items[i]));
    }
}
