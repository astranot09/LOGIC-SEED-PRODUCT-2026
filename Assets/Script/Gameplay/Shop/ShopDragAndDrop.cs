using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class ShopDragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 originalPosition;

    [Header("New Input System Events")]
    // Event ketika sedang di-drag (mengirim posisi pointer real-time)
    public UnityEvent<Vector2> OnUIDragging;
    // Event ketika dilepas/drop (mengirim posisi pointer terakhir)
    public UnityEvent<Vector2> OnUIDropped;
    // Event ketika batal/gagal drop di area target
    public UnityEvent OnUIDragCancelled;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = gameObject.AddComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = rectTransform.anchoredPosition;
        canvasGroup.blocksRaycasts = false; // Biar raycast tembus ke world belakangnya
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Mengikuti pointer New Input System
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

        // Panggil event dragging untuk dibaca oleh sistem preview di world
        OnUIDragging?.Invoke(eventData.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        // Lempar event drop untuk dieksekusi oleh Spawner
        OnUIDropped?.Invoke(eventData.position);
    }

    // Fungsi publik jika ingin membatalkan posisi UI dari script luar
    public void ResetToOriginalPosition()
    {
        rectTransform.anchoredPosition = originalPosition;
        OnUIDragCancelled?.Invoke();
    }
}

