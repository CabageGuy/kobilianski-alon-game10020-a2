using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public int totalCoins;
    private int currentCoins = 0;

    public UnityEvent<int> onCoinCollected;   // sends current coin count
    public UnityEvent onAllCoinsCollected;    // fires when done

    public void CollectCoin()
    {
        currentCoins++;

        // Update UI
        onCoinCollected.Invoke(currentCoins);

        // Check win condition
        if (currentCoins >= totalCoins)
        {
            onAllCoinsCollected.Invoke();
        }
    }
}   