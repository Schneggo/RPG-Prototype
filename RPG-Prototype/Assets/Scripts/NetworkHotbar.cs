using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkHotbar : NetworkBehaviour
{
    public Hotbar hotbar;

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) return;
        hotbar.enabled = true;
    }
}