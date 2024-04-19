using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int[] score = new int[6];

    public int mapId;

    public static GameManager instance;

    [HideInInspector] public int timeMinus;
    [HideInInspector] public float timer;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        mapId = PlayerPrefs.GetInt("mapId");
        if(mapId == 0)
        {
            mapId = 1;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        mapId = PlayerPrefs.GetInt("mapId");
        if (mapId == 0)
        {
            mapId = 1;
        }

        Timer();
    }

    public void Timer()
    {
        timer += Time.deltaTime;
        if(timer >= 1)
        {
            timer = 0;
            timeMinus = 1;
        }
        else
        {
            timeMinus = 0;
        }
    }
}
