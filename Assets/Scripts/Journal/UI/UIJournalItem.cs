using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;

public class UIJournalItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TextMeshProUGUI _header;

    public TextMeshProUGUI Header => _header;

    public IInventoryItem Item { get;  private set; }

    private Coroutine _showTooltipWithDelay;
    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void SetUp(IInventoryItem item)
    {
        gameObject.SetActive(true);
        SetItem(item);
        SetHeader(item.ItemInfo.Title, item.State.amount);
    }

    private void SetItem(IInventoryItem item)
    {
        Item = item;
        
    }

    private void SetHeader(string header, int amount)
    {
        _header.text = $"[{header}] x{amount}";
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
