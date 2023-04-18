using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medkit : MonoBehaviour
{
    private AudioSource terrianAudio;
    [SerializeField] private AudioClip equipMedkit;
    private PopupMessage messageScript;
    void Start()
    {
        terrianAudio = GameObject.Find("Terrain").GetComponent<AudioSource>();
        messageScript = GameObject.Find("Popup").GetComponent<PopupMessage>();
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if (playerInventory)
        {
            terrianAudio.PlayOneShot(equipMedkit);
            playerInventory.IncrementHealthPacksCollected();
            Destroy(gameObject);
            messageScript.AddToQueue("Medkit Collected! Press e to activate");
        }
    }
}
