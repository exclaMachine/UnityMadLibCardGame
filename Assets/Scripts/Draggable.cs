using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector2 startPosition;
    private Transform originalParent;
    public SlotType cardType;

    private Canvas canvas;
    private CanvasGroup canvasGroup;

    void Awake()
    {
        canvas = FindObjectOfType<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null) // Ensure there is a CanvasGroup component
        {
            // Add a CanvasGroup component if not already attached
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        startPosition = transform.position;
        originalParent = transform.parent;
        transform.SetParent(canvas.transform); // Assuming a reference to the top-level canvas
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        transform.SetParent(originalParent);
        transform.position = startPosition; // Reset position or keep it based on your game logic
    }
}
