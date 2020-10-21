using System.Collections;
using UnityEngine;
using TMPro;

public class Currency : MonoBehaviour
{
    public static int coins;
    public TextMeshProUGUI coinsText;
    public void GetCoins(int amount)
    {
        coins += amount;
    }
    public void Update()
    {
        coinsText.text = "Currency: " + coins.ToString();
    }

}
