using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HUD : NetworkManager {

    public void StartupHost()
    {
        SetPort();
        NetworkManager.singleton.StartHost();
    }

    public void JoinGame()
    {
        SetIPAddress();
        SetPort();
        NetworkManager.singleton.StartClient();
    }

    void SetIPAddress()
    {
        
         string IPAddress= GameObject.Find("InputFieldText").GetComponent<Text>().text;
        NetworkManager.singleton.networkAddress = IPAddress;
            }

    void SetPort()
    {
        NetworkManager.singleton.networkPort = 7777;
    }
}
