using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("Data Item")]
    [SerializeField] private ProductionSO productionSO;

    private Canvas canvas;
    private RectTransform myRect;

    // Clone icon yang benar-benar di-drag (item asli di shop tidak disentuh sama sekali)
    [Header("Clone")]
    private RectTransform dragIconRect;
    private CanvasGroup dragIconCanvasGroup;

    void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        myRect = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(productionSO.productionPrice > PlayerProfitScript.instance.PlayerProfit) return;

        // Buat GameObject baru sebagai "kloningan" icon untuk di-drag
        GameObject dragIconObj = new GameObject("DragIcon(Clone)", typeof(RectTransform), typeof(CanvasGroup), typeof(Image));
        dragIconObj.transform.SetParent(canvas.transform, false);
        dragIconObj.transform.SetAsLastSibling();

        Image img = dragIconObj.GetComponent<Image>();
        img.sprite = productionSO.sprite;
        img.raycastTarget = false; // penting: supaya tidak menghalangi raycast pas drop

        dragIconRect = dragIconObj.GetComponent<RectTransform>();
        dragIconRect.sizeDelta = myRect.sizeDelta; // samain ukuran sama icon asli
        dragIconRect.position = eventData.position;

        dragIconCanvasGroup = dragIconObj.GetComponent<CanvasGroup>();
        dragIconCanvasGroup.alpha = 0.85f;
        dragIconCanvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (dragIconRect != null)
            dragIconRect.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (dragIconRect == null) return;

        // Konversi posisi mouse (screen space) ke posisi dunia 2D
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(eventData.position);
        Collider2D hit = Physics2D.OverlapPoint(worldPoint);

        if (hit != null)
        {
            DropSlot slot = hit.GetComponent<DropSlot>();
            if (slot != null)
            {
                slot.SetItem(productionSO);
            }
        }

        // Clone selalu dihapus setelah drag selesai (berhasil ataupun tidak)
        // Item asli di panel shop tidak pernah berubah/hilang
        if (dragIconRect != null)
        {
            Destroy(dragIconRect.gameObject);
            dragIconRect = null;
        }
    }

    public void SetUp(ProductionSO productionSO)
    {
        this.productionSO = productionSO;
    }
}