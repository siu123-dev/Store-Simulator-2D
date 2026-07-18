using UnityEngine;

public class LoadShelfs : MonoBehaviour
{
    private SettManagers setts;

    public GameObject shelfPrefab;

    void Awake()
    {
        setts = FindAnyObjectByType<SettManagers>();
    }

    void Start()
    {
        foreach(ShelfSaveData data in SaveSystem.Instance.Data.shelfs)
        {
            GameObject obj = Instantiate(shelfPrefab);

            Shelf shelf = obj.GetComponent<Shelf>();

            shelf.currentAmount = data.amount;

            shelf.transform.position = data.position;
            shelf.transform.eulerAngles = data.rotation;

           shelf.currentProduct = ProductDatabase.Instance.GetProduct(data.productID);

            Debug.Log("Gespeicherte ID: " + data.productID);
            Debug.Log("Gefundenes Produkt: " + shelf.currentProduct);

            shelf.RefreshUI();

        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.P) && Input.GetKey(KeyCode.O))
        {

            SaveSystem.Instance.Data.shelfs.Clear();
            #pragma warning disable
            Shelf[] shelfs = FindObjectsByType<Shelf>(FindObjectsSortMode.None);

            foreach(Shelf shelf in shelfs)
            {
                ShelfSaveData data = new ShelfSaveData();

                data.position = shelf.transform.position;
                data.rotation = shelf.transform.eulerAngles;
                data.amount = shelf.currentAmount;

                if (shelf.currentProduct != null)
                {
                    data.productID = shelf.currentProduct.id;
                }

                SaveSystem.Instance.Data.shelfs.Add(data);

                shelf.RefreshUI();
            }

            SaveSystem.Instance.Save();
        }
    }
}
