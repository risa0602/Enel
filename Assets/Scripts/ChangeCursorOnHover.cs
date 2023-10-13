using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeCursorOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Texture2D cursorTexture; // カーソルに表示する画像
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    // マウスがボタン上に入った時の処理
    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    // マウスがボタン上から出た時の処理
    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}