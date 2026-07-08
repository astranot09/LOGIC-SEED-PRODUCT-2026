using System;
using UnityEngine;

// Taruh script ini di GameObject target yang boleh menerima item.
// GameObject ini WAJIB punya Collider2D (boleh Is Trigger = true).
public class DropSlot : MonoBehaviour
{
    [SerializeField] private ProductionSO currentProductionSO;
    //public bool IsEmpty() => string.IsNullOrEmpty(currentItemID);

    public virtual void SetItem(ProductionSO newProductionSO)
    {
        currentProductionSO = newProductionSO;

        //if (prefab != null)
        //{
        //    spawnedVisual = Instantiate(prefab, transform.position, Quaternion.identity, transform);
        //}

        Debug.Log($"Item '{currentProductionSO.productionName}' berhasil dipasang ke slot {gameObject.name}");
    }

    //public void ClearItem()
    //{
    //    currentProductionSO = null;
    //    //if (spawnedVisual != null) Destroy(spawnedVisual);
    //}

}