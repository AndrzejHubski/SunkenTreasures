using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockTreasure : MonoBehaviour
{
    public GameObject panelGem5, panelGem6;
    public UIManager uIManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("mapPieces" + 2) >= 16 && PlayerPrefs.GetInt("isShowed" + 2) != 1)
        {
            uIManager.OpenPanel("Gem5");
            PlayerPrefs.SetInt("isShowed" + 2, 1);
        }
        if (PlayerPrefs.GetInt("mapPieces" + 3) >= 16 && PlayerPrefs.GetInt("isShowed" + 3) != 1)
        {

            uIManager.OpenPanel("Gem6");
            PlayerPrefs.SetInt("isShowed" + 3, 1);
        }
    }
}
