using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class draggableItem : MonoBehaviour, IDragHandler , IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private Vector3 currentPosition;

    public GameObject unit;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        currentPosition = rectTransform.localPosition;
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rectTransform.localPosition = currentPosition;
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
}
