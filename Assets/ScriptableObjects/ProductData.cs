using UnityEngine;

[CreateAssetMenu(fileName = "New Product", menuName = "Store/Product")]
public class ProductData : ScriptableObject
{
    public float marketPrice;
    public int maxStackSize;
    public float playerPrice;

    public Sprite icon;
}
