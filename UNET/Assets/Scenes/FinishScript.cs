using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class FinishScript : NetworkBehaviour {

    public PlayerLives redLivesS;
    public PlayerLives blueLivesS;
    public PlayerLives yellowLivesS;
    public PlayerLives greenLivesS;
    public GameObject gameHUD;
    public GameObject finishHUD;
    public NetworkManager netManager;

    public Text winnerText;
	// Use this for initialization
	void Start () {
        //winnerText = GameObject.Find("WinnerText").GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () {
        int redLives = redLivesS.ActualLives();
        int blueLives = blueLivesS.ActualLives();
        int greenLives = greenLivesS.ActualLives();
        int yellowLives = yellowLivesS.ActualLives();

        if(redLives > 0 && blueLives <= 0 && greenLives <= 0 && yellowLives <= 0)
        {
            gameHUD.SetActive(false);
            finishHUD.SetActive(true);
            winnerText.text = "PLAYER RED \n WINS!";

        }
        if (redLives <= 0 && blueLives > 0 && greenLives <= 0 && yellowLives <= 0)
        {
            gameHUD.SetActive(false);
            finishHUD.SetActive(true);
            winnerText.text = "PLAYER BLUE \n WINS!";
        }
        if (redLives <= 0 && blueLives <= 0 && greenLives > 0 && yellowLives <= 0)
        {
            gameHUD.SetActive(false);
            finishHUD.SetActive(true);
            winnerText.text = "PLAYER GREEN \n WINS!";
        }
        if (redLives <= 0 && blueLives <= 0 && greenLives <= 0 && yellowLives > 0)
        {
            gameHUD.SetActive(false);
            finishHUD.SetActive(true);
            winnerText.text = "PLAYER YELLOW \n WINS!";
        }
    }
    public void Restart()
    {
        if (hasAuthority)
            netManager.StopHost();
        else
            netManager.StopClient();
        SceneManager.LoadScene("SampleScene",LoadSceneMode.Single);

    }

}
