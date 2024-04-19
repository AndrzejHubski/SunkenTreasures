using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gem : MonoBehaviour
{
    public int id;
    private int gemsRange;
    public float lifeTime;
    public bool isSpawned = false;

    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public TMP_Text lifetimeText;

    public LayerMask diamondLayer;

    // Start is called before the first frame update
    void Start()
    {
        diamondLayer = LayerMask.GetMask("Diamonds");
        if (PlayerPrefs.GetInt("mapPieces" + 3) >= 16)
        {
            gemsRange = 6;
        }
        else if(PlayerPrefs.GetInt("mapPieces" + 2) >= 16)
        {
            gemsRange = 5;
        }
        else
        {
            gemsRange = 4;
        }
        id = Random.Range(0, gemsRange);
        spriteRenderer.sprite = sprites[id];
        lifeTime = Mathf.RoundToInt(Random.Range(3, 6));
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= GameManager.instance.timeMinus;

        if(lifeTime <= 0)
        {
            SetNewGem();
        }

        lifetimeText.text = Mathf.RoundToInt(lifeTime).ToString();

        CheckBottomGem();
    }

    public void SetNewGem()
    {
        int newId = Random.Range(0, gemsRange);
        while (newId == id)
        {
            newId = Random.Range(0, gemsRange);
        }
        id = newId;
        spriteRenderer.sprite = sprites[id];
        lifeTime = Mathf.RoundToInt(Random.Range(3, 6));
    }

    public void CheckBottomGem()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position - new Vector3(0, 0.5f, 0), Vector3.down, diamondLayer);

        // Проверяем столкновение луча с объектами на слое diamondLayer
        if (hit.collider != null)
        {
            if(Mathf.Abs(transform.position.y - hit.collider.transform.position.y) > 1)
            {
                transform.Translate(Vector2.down * 10 * Time.deltaTime);
            }
            else
            {
                transform.position = new Vector2(transform.position.x, Mathf.RoundToInt(transform.position.y));
            }
        }
        else if(transform.position.y > 0)
        {
            transform.Translate(Vector2.down * 10 * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, 0);
        }

    }

    public void SetLifetime()
    {

    }
}
