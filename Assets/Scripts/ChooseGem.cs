using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseGem : MonoBehaviour
{
    public List<Gem> selectedDiamonds;
    public LayerMask diamondLayer;



    // Start is called before the first frame update
    void Start()
    {
        diamondLayer = LayerMask.GetMask("Diamonds");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, diamondLayer);
            if (hit.collider != null)
            {
                Gem gemScript = hit.collider.GetComponent<Gem>();
                if(gemScript != null)
                {
                    if (selectedDiamonds.Count == 0)
                    {
                        selectedDiamonds.Add(gemScript);
                    }
                    else if (NewGem(gemScript) == true && gemScript.id == selectedDiamonds[0].id && GemsDistance(gemScript) < 1.7f)
                    {
                        selectedDiamonds.Add(gemScript);
                    }
                }

                Debug.Log(GemsDistance(gemScript));
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if(selectedDiamonds.Count >= 3)
            {
                MissionController.instance.gemsCount[selectedDiamonds[0].id] -= selectedDiamonds.Count;
                foreach (Gem gem in selectedDiamonds)
                {
                    Destroy(gem.gameObject);
                }
            }
            AbortCombo();
        }

        CheckGems();
    }

    public float GemsDistance(Gem newGem)
    {
        Vector2 gemsDist = newGem.transform.position - selectedDiamonds[selectedDiamonds.Count - 1].transform.position;
        return Mathf.Abs(gemsDist.magnitude);
    }

    public bool NewGem(Gem newGem)
    {
        bool isNew = true;
        foreach(Gem oldGem in selectedDiamonds)
        {
            if (newGem == oldGem)
                isNew = false;
        }
        return isNew;
    }

    public void CheckGems()
    {
        for(int i = 0; i < selectedDiamonds.Count - 1; i++)
        {
            if (selectedDiamonds[i].id != selectedDiamonds[i + 1].id)
            {
                if (selectedDiamonds.Count >= 3)
                {
                    MissionController.instance.gemsCount[selectedDiamonds[0].id] -= selectedDiamonds.Count;
                    foreach (Gem gem in selectedDiamonds)
                    {
                        Destroy(gem.gameObject);
                    }
                }
                AbortCombo();
            }
        }
    }

    public void AbortCombo()
    {
        selectedDiamonds.RemoveRange(0, selectedDiamonds.Count);
    }
}
