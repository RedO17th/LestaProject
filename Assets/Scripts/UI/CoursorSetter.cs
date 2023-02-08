using UnityEngine;

public class CoursorSetter : MonoBehaviour
{
    [SerializeField] private Sprite cursorSprite;
    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;
    void Start()
    {
        Cursor.SetCursor(cursorSprite.texture, hotSpot, cursorMode);
    }
}
