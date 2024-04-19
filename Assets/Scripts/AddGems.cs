using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGems : MonoBehaviour
{
    public GameObject gemPrefab;
    public Transform gemParent;

    public LayerMask diamondLayer;

    // Start is called before the first frame update
    void Start()
    {
        diamondLayer = LayerMask.GetMask("Diamonds");
    }

    // Update is called once per frame
    void Update()
    {
        CheckBottomGem();
    }


    public void CheckBottomGem()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, 10, diamondLayer);

        // Проверяем столкновение луча с объектами на слое diamondLayer
        if (hit.collider != null)
        {
            Debug.Log("Hit");
            if (Mathf.Abs(transform.position.y - hit.collider.transform.position.y) > 1.2f)
            {
                GameObject gem = Instantiate(gemPrefab, transform.position, transform.rotation, gemParent);
                gem.GetComponent<Gem>().isSpawned = true;
            }
        }
    }
}
