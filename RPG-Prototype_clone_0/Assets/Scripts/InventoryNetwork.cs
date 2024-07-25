using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class InventoryNetwork : NetworkBehaviour
{
    public List<ItemScriptableObject> items = new List<ItemScriptableObject>();
    public List<NetworkItem> NetworkItems = new List<NetworkItem>();

    public void AddItem(ItemScriptableObject Item)
    {
        items.Add(Item);
    }

    public void AddNetworkItem(NetworkItem netItem)
    {
        NetworkItems.Add(netItem);
    }
}