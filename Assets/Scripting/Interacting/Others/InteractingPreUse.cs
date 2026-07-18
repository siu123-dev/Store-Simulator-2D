using UnityEngine;

public class InteractingPreUse : MonoBehaviour //Got Script für alle Interactables
{
    private SettManagers setts;
    [Header("Presets")]
    public GameObject Tipp;
    public Transform objectTipp;
    public Rigidbody2D rb;
    public PoolRequired prPresets;
    [Space]
    [Header("Bools")]
    public bool canInteract = false;
    public bool isInteracting = false;

    [Header("Art")]

    public bool isPackage;

    void Start()
    {
        setts = FindAnyObjectByType<SettManagers>();
    }

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
        if(setts.currentMode == CurrentMode.Gameplay)
        {
            if (canInteract && Input.GetKeyDown(KeyCode.E) && !isInteracting)
            {
                Tipp.SetActive(false);
                rb.simulated = false;

                GetItself();

                transform.SetParent(prPresets.playerArmTransform);
                transform.position = prPresets.playerArmTransform.position;

                canInteract = false;
                isInteracting = true;

                Package pkcg = GetComponent<Package>();

                if (pkcg == null)
                {
                    Debug.LogError("Package wurde NICHT gefunden!");
                }
                else
                {
                    Debug.Log("Package gefunden!");
                }
                setts.holdedPackage = pkcg;
                setts.currentSlot = HoldingInfo.Package;

                Debug.Log("Is Holding: " + setts.holdedPackage.name);
            }
            else if(isInteracting && Input.GetKeyDown(KeyCode.E))
            {
                rb.simulated = true;

                transform.SetParent(null);
                setts.holdedPackage = null;
                setts.currentSlot = HoldingInfo.None;
                
                isInteracting = false;

                Debug.Log("Is Holding: " + setts.holdedPackage.name);

                canInteract = true;
            }
        }
    }

    public void GetItself()
    {
        if (isPackage)
        {
            setts.currentSlot = HoldingInfo.Package;
        }
    }
}
