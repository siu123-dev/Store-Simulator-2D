using UnityEngine;

public class InteractingPreUse : MonoBehaviour //Got Script für alle Interactables
{
    [Header("Presets")]
    public GameObject Tipp;
    public Transform objectTipp;
    public Rigidbody2D rb;
    public PoolRequired prPresets;
    [Space]
    [Header("Bools")]
    public bool canInteract = false;
    public bool isInteracting = false;


    void Awake()
    {
        prPresets = FindAnyObjectByType<PoolRequired>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Tipp.SetActive(true);
            canInteract = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Tipp.SetActive(false);
            canInteract = false;
        }
    }

    public void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            Tipp.SetActive(false);
            rb.simulated = false;
            transform.SetParent(prPresets.playerArmTransform);
            transform.position = prPresets.playerArmTransform.position;
            canInteract = false;
            isInteracting = true;
        }
        else if(isInteracting && Input.GetKeyDown(KeyCode.E))
        {
            canInteract = true;
            rb.simulated = true;
            transform.SetParent(null);
            isInteracting = false;
        }
    }
}
