using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkItem : NetworkBehaviour
{
    public ItemScriptableObject ItemObject;

    private void OnTriggerEnter(Collider other)
    {
        var inventory = other.GetComponent<InventoryNetwork>();
        inventory.AddItem(ItemObject);
        Debug.Log($"added {ItemObject.ItemName} to {inventory.OwnerClientId}");
        DespawnItemRpc();
    }

    [Rpc(SendTo.Server)]
    private void DespawnItemRpc()
    {
        this.GetComponent<NetworkObject>().Despawn(true);
    }
}