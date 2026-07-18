using TMPro;
using UnityEngine;

public class Package : MonoBehaviour
{
    public ProductData product;
    public int amount;
    public SpriteRenderer productPreset;
    public TMP_Text amountTMP;


    public SettManagers setts;

    public void RefreshUI()
{
    if(product != null)
    {
        productPreset.sprite = product.icon;
    }

    amountTMP.text = amount.ToString();
}

    void Update()
    {
        amountTMP.text = amount.ToString();
    }
}
