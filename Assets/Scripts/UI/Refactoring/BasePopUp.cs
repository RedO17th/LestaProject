using TMPro;
using UnityEngine;

public class BasePopUp : BaseWindow
{
    [SerializeField] public TextMeshProUGUI _header = null;

    [SerializeField] private TextMeshProUGUI _content = null;

    private RectTransform rt = null;

    public void SetHeaderText(string text)
    {
        _header.text = text;
    }


    public void SetContentText(string text)
    {
        _content.text = text;
    }

    public void SetPosition(Vector2 position)
    {
        if (rt == null)
        {
            rt = GetComponent<RectTransform>();
        }
        float xPosition = position.x + rt.rect.width / 2;
        float yPosition = position.y - rt.rect.height / 2;
        transform.position = new Vector2(xPosition, yPosition);
    }
}
