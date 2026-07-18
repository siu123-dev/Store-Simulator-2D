using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractShelf : MonoBehaviour
{
    private List<GameObject> nearbyShelves = new List<GameObject>();
    public GameObject interactedShelf;
    public Shelf shelfRfr;
    private SettManagers setts;
    public bool canAuffüllen = false;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AnyShelf"))
        {
            nearbyShelves.Add(collision.gameObject);
            UpdateInteractedShelf();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("AnyShelf"))
        {
            nearbyShelves.Remove(collision.gameObject);
            UpdateInteractedShelf();
        }
    }

    private void UpdateInteractedShelf()
    {
        if (nearbyShelves.Count > 0)
        {
            interactedShelf = nearbyShelves[nearbyShelves.Count - 1]; // zuletzt betretenes Regal
            shelfRfr = interactedShelf.GetComponent<Shelf>();
            canAuffüllen = true;
        }
        else
        {
            interactedShelf = null;
            shelfRfr = null;
            canAuffüllen = false;
        }
    }

    void Start()
    {
        setts = FindAnyObjectByType<SettManagers>();
    }

    void Update()
    {
        if (canAuffüllen && shelfRfr != null) // Sicherheitsnetz
        {
            if (Input.GetMouseButtonDown(0) && setts.currentMode == CurrentMode.Gameplay && setts.currentSlot == HoldingInfo.Package)
            {
                shelfRfr.AddProducts(setts.holdedPackage);
            }

            if(Input.GetMouseButtonDown(1) && setts.currentMode == CurrentMode.Gameplay && setts.currentSlot == HoldingInfo.Package)
            {
                shelfRfr.RemoveProducts(setts.holdedPackage);
            }
        }
    }
}