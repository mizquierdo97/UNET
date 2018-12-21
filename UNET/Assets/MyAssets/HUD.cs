using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HUD : NetworkManager {

    public GameObject MyHUD;
    public GameObject GameHUD;
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
    public void StartGame()
    {
        int dropdownVal = GameObject.Find("Dropdown").GetComponent<Dropdown>().value;

        switch (dropdownVal)
        {
            case 0:
                StartupHost();
                break;

            case 1:
                JoinGame();
                break;
        }

        MyHUD.SetActive(false);
        GameHUD.SetActive(true);
    }
    public void DisableHUD()
    {
        MyHUD.SetActive(false);
    }
}
