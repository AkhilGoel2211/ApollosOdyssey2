using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medkit : MonoBehaviour
{
    private AudioSource terrianAudio;
    [SerializeField] private AudioClip equipMedkit;

    void Start()
    {
        terrianAudio = GameObject.Find("Terrain").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if (playerInventory)
        {
            terrianAudio.PlayOneShot(equipMedkit);
            playerInventory.IncrementHealthPacksCollected();
            Destroy(gameObject);
            var popup = new PopupMessage();
            popup.AddToQueue("Medkit Collected! Press e to activate");
        }
    }
}
