using TMPro;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    public TMP_Text amountText;
    public Sprite iconSpr;
    public SpriteRenderer iconRndr;
    public ProductData currentProduct;
    public int currentAmount = 0;

    public void RefreshUI()
    {
        if(currentProduct != null)
        {
            iconRndr.sprite = currentProduct.icon;
        }
        else
        {
            iconRndr.sprite = null;
        }

        amountText.text = currentAmount.ToString();
    }


    public bool AddProducts(Package package)
    {
        if(package.amount <= 0) return false;

        if(currentProduct == null) currentProduct = package.product;

        if(currentProduct != null && package.product != currentProduct)
        {
            Debug.LogWarning("Can`t mix products");
            return false;
        }


        int remainingSpace = currentProduct.maxStackSize - currentAmount;
        if(remainingSpace <= 0) return false;

        int amountToMove = Mathf.Min(remainingSpace, package.amount);

        currentAmount += amountToMove;
        package.amount -= amountToMove;

        RefreshUI();

        return true;
    }

    public bool RemoveProducts(Package package)
    {
        Debug.Log("AUFGERUFEN Remove Prdcts");
        if(package.amount >= package.product.maxStackSize) return false;

        if(currentProduct == null) return false;

        if(currentProduct != null && package.product != currentProduct)
        {
            Debug.LogWarning("Can`t mix products | Remove");
            return false;
        }

        int remainingSpace = package.product.maxStackSize - package.amount;
        if(remainingSpace <= 0) return false;

        int amountToMove = Mathf.Min(remainingSpace, currentAmount);

        currentAmount -= amountToMove;
        if(currentAmount <= 0)
        {
            currentAmount = 0;
            currentProduct = null;
        }
        package.amount += amountToMove;

        RefreshUI();


        return true;
    }
}
