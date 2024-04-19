using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapsUnlock : MonoBehaviour
{
    public Button bermudian, mexican;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("mapPieces" + 1) >= 16)
        {
            bermudian.interactable = true;
        }
        if (PlayerPrefs.GetInt("mapPieces" + 2) >= 16)
        {
            mexican.interactable = true;
        }
    }
}
