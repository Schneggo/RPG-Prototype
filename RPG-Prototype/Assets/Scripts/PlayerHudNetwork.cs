using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerHudNetwork : NetworkBehaviour
{
    [SerializeField] private Canvas ui;
    [SerializeField] private Transform player;

    public override void OnNetworkSpawn()
    {
        Instantiate(ui, player);
    }
}