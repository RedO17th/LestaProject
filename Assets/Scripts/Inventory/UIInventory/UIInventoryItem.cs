using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UIInventoryItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Image _imageIcon;
    [SerializeField] private TextMeshProUGUI _textAmount;

    private RectTransform _rectTransform;
    private Canvas _mainCanvas;
    private CanvasGroup _canvasGroup;
    private Coroutine _showTooltipWithDelay;

    public IInventoryItem Item { get; private set; }

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _mainCanvas = GetComponentInParent<Canvas>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        var slotTransform = _rectTransform.parent;
        slotTransform.SetAsLastSibling();

        var inventoryGridTransform = slotTransform.parent;
        inventoryGridTransform.SetAsLastSibling();

        var inventoryPanelTransform = inventoryGridTransform.parent;
        inventoryPanelTransform.SetAsLastSibling();

        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _mainCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;

        _canvasGroup.blocksRaycasts = true;
    }

    public void Refresh(IInventorySlot slot)
    {
        if(slot.IsEmpty)
        {
            Disable();
            return;
        }

        Item = slot.Item;
        _imageIcon.sprite = Item.ItemInfo.SpriteIcon;
        _imageIcon.gameObject.SetActive(true);

        var textAmountEnabled = slot.Amount > 1;
        _textAmount.gameObject.SetActive(textAmountEnabled);

        if(textAmountEnabled)
            _textAmount.text = $"x{slot.Amount.ToString()}";
    }

    private void Disable()
    {
        _textAmount.gameObject.SetActive(false);
        _imageIcon.gameObject.SetActive(false);
    }

    
    public void OnPointerEnter(PointerEventData eventData)
    {
        string header = Item.ItemInfo.Title;

        string itemType = ItemTypesDictionary.GetValue(Item.Type);
        
        string content = itemType + "\n";

        content += Item.ItemInfo.Description + "\n";

        if (Item.ItemInfo.Price != 0)
            content += "Цена: " + Item.ItemInfo.Price.ToString() + "\n";

        _showTooltipWithDelay = StartCoroutine(ShowTooltipWithDelayRoutine(content, header));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_showTooltipWithDelay == null)
            return;

        StopCoroutine(_showTooltipWithDelay);
        TooltipSystem.Hide();
    }

    private IEnumerator ShowTooltipWithDelayRoutine(string content, string header)
    {
        yield return new WaitForSeconds(0.5f);
        //Vector2 position = Camera.current.WorldToScreenPoint(_rectTransform.position);
        Vector2 position = _rectTransform.position;
        TooltipSystem.Show(position, content, header);
    }
}