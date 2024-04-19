using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MapInf : MonoBehaviour
{
    public TMP_Text[] piecesText;


    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i<piecesText.Length; i++)
        {
            if (piecesText[i].text != null)
            {
                piecesText[i].text = PlayerPrefs.GetInt("mapPieces" + PlayerPrefs.GetInt("mapId")) + "/16".ToString();
            }
        }
    }

}
