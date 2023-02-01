 using UnityEngine;
using UnityEngine.UI;
using TMPro;

[ExecuteInEditMode()]
public class Tooltip : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _headerField;
    [SerializeField] private TextMeshProUGUI _contentField;

    [SerializeField] private LayoutElement _layoutElement;

    [SerializeField] private int _characterWrapLimit;

    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void SetText(string content, string header = "")
    {
        if (string.IsNullOrEmpty(header))
            _headerField.gameObject.SetActive(false);
        else
        {
            _headerField.gameObject.SetActive(true);
            _headerField.text = header;
        }

        _contentField.text = content;

        Rescale();
    }

    private void Rescale()
    {
        int headerLength = _headerField.text.Length;
        int contentLength = _contentField.text.Length;

        _layoutElement.enabled = (headerLength > _characterWrapLimit || contentLength > _characterWrapLimit) ? true : false;
    }

    private void LocateOnMousePosition()
    {
        Vector2 position = Input.mousePosition;

        Locate(position);
    }

    public void Locate(Vector2 position)
    {
        float pivotX = position.x / Screen.width;
        float pivotY = position.y / Screen.height;

        _rectTransform.pivot = new Vector2(pivotX, pivotY);
        transform.position = position;
    }
}
