using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medkit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if (playerInventory)
        {
            playerInventory.IncrementHealthPacksCollected();
            Destroy(gameObject);
        }
    }
}
