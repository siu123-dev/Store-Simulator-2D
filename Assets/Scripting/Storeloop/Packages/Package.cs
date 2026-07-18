using TMPro;
using UnityEngine;

public class Package : MonoBehaviour
{
    public ProductData product;
    public int amount;
    public Sprite productIcon;
    public SpriteRenderer productPreset;
    public TMP_Text amountTMP;


    public SettManagers setts;

    void Start()
    {
        productPreset.sprite = productIcon;
    }

    void Update()
    {
        amountTMP.text = amount.ToString();
    }
}
