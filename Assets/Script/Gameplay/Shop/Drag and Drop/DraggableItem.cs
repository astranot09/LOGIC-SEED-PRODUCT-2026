using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("Data Item")]
    public string itemID;
    public Sprite itemIcon;
    public GameObject itemPrefab; // prefab visual yang akan dipasang ke slot

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Canvas canvas;
    private Transform originalParent;
    private Vector2 originalAnchoredPos;

    [Header("Reference")]
    [SerializeField] private ItemScript itemShopScript;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        originalAnchoredPos = rectTransform.anchoredPosition;

        // Pindahkan ke root canvas supaya icon tampil paling atas & tidak menghalangi raycast-nya sendiri
        transform.SetParent(canvas.transform, true);
        transform.SetAsLastSibling();

        canvasGroup.blocksRaycasts = false; // biar raycast bisa "tembus" ke bawah icon
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        // Konversi posisi mouse (screen space) ke posisi dunia 2D
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(eventData.position);
        Collider2D hit = Physics2D.OverlapPoint(worldPoint);

        bool berhasilDipasang = false;

        if (hit != null)
        {
            DropSlot slot = hit.GetComponent<DropSlot>();
            if (slot != null && slot.IsEmpty())
            {
                slot.SetItem(itemID, itemIcon, itemPrefab);
                berhasilDipasang = true;
            }
        }

        if (berhasilDipasang)
        {
            // Item berhasil dipasang -> hapus icon dari shop
            Destroy(gameObject);
        }
        else
        {
            // Gagal (tidak kena slot / slot sudah terisi) -> kembalikan ke posisi semula
            transform.SetParent(originalParent, true);
            rectTransform.anchoredPosition = originalAnchoredPos;
        }
    }
}