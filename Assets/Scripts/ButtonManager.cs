using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public CountdownTimer countdownTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Gift()
    {
        if(countdownTimer.bonusReady == true)
        {
            for (int i = 0; i < 3; i++)
            {
                if (PlayerPrefs.GetInt("mapPieces" + GameManager.instance.mapId) < 16)
                {
                    PlayerPrefs.SetInt("mapPieces" + GameManager.instance.mapId, (PlayerPrefs.GetInt("mapPieces" + GameManager.instance.mapId) + 1));
                    int pieceUnlock = Random.Range(0, 16);
                    while (PlayerPrefs.GetInt("map" + GameManager.instance.mapId + "piece" + pieceUnlock) == 1)
                    {
                        pieceUnlock = Random.Range(0, 16);
                    }
                    PlayerPrefs.SetInt("map" + GameManager.instance.mapId + "piece" + pieceUnlock, 1);
                }
            }
            countdownTimer.bonusReady = false;
            PlayerPrefs.SetInt("bonusReady", 1);
            countdownTimer.ResetTimer();
        }
    }

    public void SetCaribbean()
    {
        PlayerPrefs.SetInt("mapId", 1);
    }

    public void SetBermudian()
    {
        PlayerPrefs.SetInt("mapId", 2);
    }

    public void SetMexican()
    {
        PlayerPrefs.SetInt("mapId", 3);
    }

    public void BuyPremium()
    {
        PlayerPrefs.SetInt("Premium", 1);

        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.GetInt("mapPieces" + GameManager.instance.mapId) < 16)
            {
                PlayerPrefs.SetInt("mapPieces" + GameManager.instance.mapId, (PlayerPrefs.GetInt("mapPieces" + GameManager.instance.mapId) + 1));
                int pieceUnlock = Random.Range(0, 16);
                while (PlayerPrefs.GetInt("map" + GameManager.instance.mapId + "piece" + pieceUnlock) == 1)
                {
                    pieceUnlock = Random.Range(0, 16);
                }
                PlayerPrefs.SetInt("map" + GameManager.instance.mapId + "piece" + pieceUnlock, 1);
            }
        }
    }

    public void Restore()
    {

    }

    public void ToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
