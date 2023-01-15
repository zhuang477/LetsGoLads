using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MonopolyNetworkManager : NetworkManager
{

    public override void OnStartServer()
    {
        base.OnStartServer();
    }

    public override void OnClientConnect()
    {
        base.OnClientConnect();


    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);


    }

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {

    }
}
