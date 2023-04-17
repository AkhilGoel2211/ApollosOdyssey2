using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    private AudioSource terrianAudio;
    [SerializeField] private AudioClip equipAmmo;

     void Start()
    {
        terrianAudio = GameObject.Find("Terrain").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if (playerInventory)
        {
            terrianAudio.PlayOneShot(equipAmmo);
            playerInventory.IncrementAmmo();
            Destroy(gameObject);
        }
    }
}
