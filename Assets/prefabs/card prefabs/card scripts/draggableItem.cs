using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class draggableItem : MonoBehaviour, IDragHandler , IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    public LayerMask groundLayer;

    private Vector3 currentPosition;

    public GameObject unit;
    public Transform champSpawnPoint;
    public int manaRequirement;


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
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out var hit, Mathf.Infinity ,groundLayer))
        {
            Instantiate(unit,hit.point, Quaternion.identity);
        }

        rectTransform.localPosition = currentPosition;
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

    }
}
