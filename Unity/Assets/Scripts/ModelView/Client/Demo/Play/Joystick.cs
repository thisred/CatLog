using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private RectTransform joystickBackground;
    private RectTransform thumb;

    public Action<Vector2> OnJoystickDownEvent; // 按下事件
    public Action<Vector2> OnJoystickUpEvent; // 抬起事件
    public Action<Vector2> OnJoystickMoveEvent; // 滑动事件

    private void Awake()
    {
        joystickBackground = GetComponent<RectTransform>();
        thumb = transform.GetChild(0).GetComponent<RectTransform>();
    }

    /// <summary>
    /// 按下
    /// </summary>
    public void OnPointerDown(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBackground, eventData.position, eventData.pressEventCamera, out var pos))
        {
            var sizeDelta = this.joystickBackground.sizeDelta;
            pos.x = (pos.x / sizeDelta.x);
            pos.y = (pos.y / sizeDelta.y);
            var inputVector = new Vector2(pos.x * 2, pos.y * 2);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;
            OnJoystickDownEvent?.Invoke(inputVector);
            thumb.anchoredPosition = new Vector2(inputVector.x * (sizeDelta.x / 3), inputVector.y * (sizeDelta.y / 3));
        }
    }

    /// <summary>
    /// 抬起
    /// </summary>
    public void OnPointerUp(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBackground, eventData.position, eventData.pressEventCamera, out var pos))
        {
            var sizeDelta = this.joystickBackground.sizeDelta;
            pos.x = (pos.x / sizeDelta.x);
            pos.y = (pos.y / sizeDelta.y);
            var inputVector = new Vector2(pos.x * 2, pos.y * 2);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;
            thumb.anchoredPosition = Vector2.zero;
            OnJoystickUpEvent?.Invoke(inputVector);
        }
    }

    /// <summary>
    /// 滑动
    /// </summary>
    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBackground, eventData.position, eventData.pressEventCamera, out var pos))
        {
            var sizeDelta = this.joystickBackground.sizeDelta;
            pos.x = (pos.x / sizeDelta.x);
            pos.y = (pos.y / sizeDelta.y);
            var inputVector = new Vector2(pos.x * 2, pos.y * 2);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;
            thumb.anchoredPosition = new Vector2(inputVector.x * (sizeDelta.x / 3), inputVector.y * (sizeDelta.y / 3));
            OnJoystickMoveEvent?.Invoke(inputVector);
        }
    }
}