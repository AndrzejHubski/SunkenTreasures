using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGems : MonoBehaviour
{
    public GameObject gemPrefab;
    public Transform gemParent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        GameObject gem = Instantiate(gemPrefab, transform.position, transform.rotation, gemParent);
        gem.GetComponent<Gem>().isSpawned = true;
    }
}
