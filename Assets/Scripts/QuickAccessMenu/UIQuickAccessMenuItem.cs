using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class UIQuickAccessMenuItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image _imageIcon;
    [SerializeField] private TextMeshProUGUI _textAmount;

    public IInventoryItem Item { get; private set; }

    private Coroutine _showTooltipWithDelay;
    private RectTransform _rectTransform;

    public int Amount => Item != null ? Item.State.amount : 0;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }
    private void Start()
    {
        PlayerInventory.Instance.Inventory.OnInventoryStateChangedEvent += OnInventoryStateChanged;
        Refresh(); ;
    }

    private void OnInventoryStateChanged(object sender)
    {
        Refresh();
    }

    public void Refresh()
    {
        if (Item == null)
        {
            Disable();
            return;
        }

        Enable();

        Item.State.amount = UpdateAmount();
        _textAmount.text = Item.State.amount.ToString();

        if (Amount == 0 && _textAmount.enabled)
        {
            _textAmount.enabled = false;
            _imageIcon.color = Color.gray;
        }
        if (Amount > 0 && !_textAmount.enabled)
        {
            _textAmount.enabled = true;
            _imageIcon.color = Color.white;
        }
    }
    private void Disable()
    {
        _imageIcon.gameObject.SetActive(false);
        _textAmount.gameObject.SetActive(false);
    }

    private void Enable()
    {
        _imageIcon.gameObject.SetActive(true);
        _textAmount.gameObject.SetActive(true);
    }

    public void SetNewItem(IInventoryItem item)
    {
        if (item == null)
            return;

        Item = item.Clone();
        _imageIcon.sprite = Item.ItemInfo.SpriteIcon;
        Refresh();
    }

    public int UpdateAmount()
    {
        return PlayerInventory.Instance.Inventory.GetItemAmountByTypeID(Item.TypeID);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Item == null)
            return;

        string header = Item.ItemInfo.Title;

        string content = Item.ItemInfo.Description + "\n";

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
