using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MonopolyNetworkPlayer : NetworkBehaviour
{
    [SyncVar][SerializeField] private string PlayerName = "nothing";

    [Server] public void SetDisplayName(string newDisplayName)
    {
        PlayerName = newDisplayName;
    }
}
