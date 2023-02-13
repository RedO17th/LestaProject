using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    private static TooltipSystem _current;

    [SerializeField] private Tooltip _tooltip;

    private void Awake()
    {
        _current = this;
    }

    public static void Show(Vector2 position, string content, string header = "")
    {
        _current._tooltip.gameObject.SetActive(true);
        _current._tooltip.SetText(content, header);

        _current._tooltip.Locate(position);
    }
    public static void Hide()
    {
        _current._tooltip.gameObject.SetActive(false);
    }

}
