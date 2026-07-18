using UnityEngine;

public class ProductDatabase : MonoBehaviour
{
    public static ProductDatabase Instance;

    public ProductData[] products;

    private void Awake()
    {
        Instance = this;
    }

    public ProductData GetProduct(string id)
    {
        foreach(ProductData product in products)
        {
            if(product.id == id)
                return product;
        }

        return null;
    }
}