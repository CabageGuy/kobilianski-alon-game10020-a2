using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameManager gameManager;

    private void Start()
    {
        // Subscribe to the event
        gameManager.onAllCoinsCollected.AddListener(OpenDoor);
    }

    public void OpenDoor(Door door)
    {
        Debug.Log("Door Opened!");
        transform.position += new Vector3(0, 3f, 0);
    }
}