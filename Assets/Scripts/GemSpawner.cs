using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    public GameObject gemPref;
    public Transform gemParent;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 6; i++)
        {
            for(int j = 0; j < 6; j++)
            {
                Instantiate(gemPref, new Vector2(i, j), Quaternion.identity, gemParent);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
