using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionController : MonoBehaviour
{
    public GameObject[] missionGems;
    public int[] gemsCount = new int[6];
    public int gemsTypes;
    public TMP_Text[] countText;

    private bool _isComplete = false;

    public GameObject EndLevelMenu;

    public static MissionController instance;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("mapPieces" + 3) >= 16)
        {
            gemsTypes = 6;
        }
        else if (PlayerPrefs.GetInt("mapPieces" + 2) >= 16)
        {
            gemsTypes = 5;
        }
        
        else
        {
            gemsTypes = 4;
        }

        for (int i = 0; i < gemsTypes; i++)
        {
            missionGems[i].SetActive(true);
            gemsCount[i] = Random.Range(21, 46);
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool isCleared = true;

        for(int i = 0; i < gemsTypes; i++)
        {
            
            if (gemsCount[i] <= 0)
            {
                gemsCount[i] = 0;
            }
            else
            {
                isCleared = false;
            }
            countText[i].text = gemsCount[i].ToString();
        }

        if(isCleared == true && _isComplete == false)
        {
            EndLevel();
        }
    }

    public void EndLevel()
    {
        EndLevelMenu.SetActive(true);
        
        if (PlayerPrefs.GetInt("mapPieces" + GameManager.instance.mapId) < 16)
        {
            PlayerPrefs.SetInt("mapPieces" + GameManager.instance.mapId, (PlayerPrefs.GetInt("mapPieces" + GameManager.instance.mapId) + 1));
            int pieceUnlock = Random.Range(0, 16);
            while(PlayerPrefs.GetInt("map"+ GameManager.instance.mapId+"piece"+pieceUnlock) == 1)
            {
                pieceUnlock = Random.Range(0, 16);
            }
            PlayerPrefs.SetInt("map" + GameManager.instance.mapId + "piece" + pieceUnlock, 1);
        }
        _isComplete = true;
    }
}
