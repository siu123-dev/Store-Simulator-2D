using TMPro;
using UnityEngine;

public class TopRightAnzeige : MonoBehaviour
{
    public TMP_Text moneyText;

    void Update()
    {
        moneyText.text = SaveSystem.Instance.Data.money.ToString() + "$";
    }
}
