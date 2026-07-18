using UnityEngine;

public class LoadPackages : MonoBehaviour
{
    private SettManagers setts;

    public GameObject packagePrefab;

    void Awake()
    {
        setts = FindAnyObjectByType<SettManagers>();
    }

    void Start()
    {
        foreach(PackageSaveData data in SaveSystem.Instance.Data.packages)
        {
            GameObject obj = Instantiate(packagePrefab);

            Package package = obj.GetComponent<Package>();

            package.amount = data.amount;

            package.transform.position = data.position;
            package.transform.eulerAngles = data.rotation;

           package.product = ProductDatabase.Instance.GetProduct(data.productID);

            Debug.Log("Gespeicherte ID: " + data.productID);
            Debug.Log("Gefundenes Produkt: " + package.product);

            package.RefreshUI();

        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.P) && Input.GetKey(KeyCode.O))
        {

            SaveSystem.Instance.Data.packages.Clear();
            #pragma warning disable
            Package[] packages = FindObjectsByType<Package>(FindObjectsSortMode.None);

            foreach(Package package in packages)
            {
                if(package.product == null)
                {
                    Debug.LogError(package.name + " hat kein Product!");
                    continue;
                }

                PackageSaveData data = new PackageSaveData();

                data.position = package.transform.position;
                data.rotation = package.transform.eulerAngles;
                
                data.amount = package.amount;
                data.productID = package.product.id;

                SaveSystem.Instance.Data.packages.Add(data);
            }

            SaveSystem.Instance.Save();
        }
    }
}
