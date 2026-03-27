using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI coinText;

    private void Start()
    {
        // Listen for coin updates
        gameManager.onCoinCollected.AddListener(UpdateCoinText);
    }

    public void UpdateCoinText(int amount)
    {
        coinText.text = "Coins: " + amount;
    }
}