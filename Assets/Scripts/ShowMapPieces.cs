using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMapPieces : MonoBehaviour
{
    public int mapId;

    public GameObject[] pieces;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LoadMapPieces();
    }

    public void LoadMapPieces()
    {
        for (int i = 0; i < 16; i++)
        {
            if (PlayerPrefs.GetInt("map" + mapId + "piece" + i) == 1)
            {
                Debug.Log("Load Piece " + i);
                pieces[i].SetActive(true);
            }
            else
            {
                pieces[i].SetActive(false);
            }
        }
    }
}
