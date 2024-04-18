using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockTreasure : MonoBehaviour
{
    public GameObject panelGem5, panelGem6;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("mapPieces" + 2) >= 16 && PlayerPrefs.GetInt("isShowed" + 2) != 1)
        {
            panelGem5.SetActive(true);
            PlayerPrefs.GetInt("isShowed" + 2, 1);
        }
        if (PlayerPrefs.GetInt("mapPieces" + 3) >= 16 && PlayerPrefs.GetInt("isShowed" + 3) != 1)
        {
            panelGem6.SetActive(true);

            PlayerPrefs.GetInt("isShowed" + 3, 1);
        }
    }
}
