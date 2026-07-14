using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private SettManagers setts;

    public GameObject shelfBeispiel;        // Das echte Regal
    public GameObject shelfPreviewBeispiel; // Das Vorschau-Regal
    public LayerMask buildingLayer;

    private Vector3 expectedRotation = Vector3.zero;

    private GameObject preview;

    void Start()
    {
        setts = FindAnyObjectByType<SettManagers>();
    }

    void Update()
    {
        if (setts.currentMode == CurrentMode.Build)
        {

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;

            // Preview erstellen (nur einmal)
            if (preview == null)
            {
                preview = Instantiate(shelfPreviewBeispiel, mousePos, Quaternion.identity);
            }

            // Preview der Maus folgen lassen
            preview.transform.position = mousePos;

            // Linksklick
            if (Input.GetMouseButtonDown(0))
            {
                PlaceShelf(mousePos, expectedRotation.z);

                Destroy(preview);
                preview = null;

                setts.currentMode = CurrentMode.Gameplay;
            }
            if (Input.GetMouseButtonDown(1))
            {
                Vector3 newRotation = new Vector3(preview.transform.eulerAngles.x, preview.transform.eulerAngles.y, preview.transform.eulerAngles.z + 90f);
                preview.transform.eulerAngles = newRotation;
                expectedRotation = preview.transform.eulerAngles;
            }
        }
        else
        {
            // Falls man den Baumodus verlässt
            if (preview != null)
            {
                Destroy(preview);
                preview = null;
            }
        }
    }

    public void PlaceShelf(Vector2 pos, float rotation)
    {
        Vector2 size = new Vector2(1f, 1f);

        Collider2D hit = Physics2D.OverlapBox(pos, size, 0f, buildingLayer);

        if (hit == null)
        {
            Instantiate(shelfBeispiel, pos, Quaternion.Euler(0, 0, rotation));;

            Debug.Log("Regal platziert");
        }
        else
        {
            Debug.Log("Hier steht bereits etwas!");
        }
    }
}