using UnityEngine;

// Taruh script ini di GameObject target yang boleh menerima item.
// GameObject ini WAJIB punya Collider2D (boleh Is Trigger = true).
public class DropSlot : MonoBehaviour
{
    private string currentItemID;
    private GameObject spawnedVisual;

    public bool IsEmpty() => string.IsNullOrEmpty(currentItemID);

    public void SetItem(string itemID, Sprite icon, GameObject prefab)
    {
        currentItemID = itemID;

        if (spawnedVisual != null) Destroy(spawnedVisual);

        if (prefab != null)
        {
            spawnedVisual = Instantiate(prefab, transform.position, Quaternion.identity, transform);
        }

        Debug.Log($"Item '{itemID}' berhasil dipasang ke slot {gameObject.name}");
    }

    public void ClearItem()
    {
        currentItemID = null;
        if (spawnedVisual != null) Destroy(spawnedVisual);
    }
}