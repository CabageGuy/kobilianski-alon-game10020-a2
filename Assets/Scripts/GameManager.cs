using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public int totalCoins;
    private int currentCoins = 0;
    public Door door; 

    public UnityEvent<int> onCoinCollected;   // sends current coin count
    public UnityEvent <Door> onAllCoinsCollected;    // fires when done
   

    public void CollectCoin()
    {
        currentCoins++;

        // Update UI
        onCoinCollected.Invoke(currentCoins);

   }

    public void Update()
    {
        // Check win condition
        if (currentCoins >= totalCoins)
        {
            onAllCoinsCollected.Invoke(door);
        }
    }
}   