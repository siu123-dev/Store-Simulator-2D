using Unity.VisualScripting;
using UnityEngine;

public class SettManagers : MonoBehaviour
{
    public CurrentMode currentMode;
    public HoldingInfo currentSlot;
    public GameObject packagePrefab;

    [Header("Products")]
    public ProductData milkProduct;
    public ProductData breadProduct;
    public ProductData riceProduct;

    [Space]
    public Package holdedPackage;

    void Start()
    {
        currentMode = CurrentMode.Gameplay;
        currentSlot = HoldingInfo.None;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameObject packageObj = Instantiate(packagePrefab, Vector3.zero, Quaternion.identity);
            Package package = packageObj.GetComponent<Package>();

            package.product = milkProduct;
            package.amount = milkProduct.maxStackSize;
            package.productIcon = milkProduct.icon;

            SaveSystem.Instance.Data.packageData.AllPackages.Add(package);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameObject packageObj = Instantiate(packagePrefab, Vector3.zero, Quaternion.identity);
            Package package = packageObj.GetComponent<Package>();

            package.product = riceProduct;
            package.amount = riceProduct.maxStackSize;
            package.productIcon = riceProduct.icon;

            SaveSystem.Instance.Data.packageData.AllPackages.Add(package);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GameObject packageObj = Instantiate(packagePrefab, Vector3.zero, Quaternion.identity);
            Package package = packageObj.GetComponent<Package>();

            package.product = breadProduct;
            package.amount = breadProduct.maxStackSize;
            package.productIcon = breadProduct.icon;

            SaveSystem.Instance.Data.packageData.AllPackages.Add(package);
        }
    }
}
