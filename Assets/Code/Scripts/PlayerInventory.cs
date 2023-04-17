using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public int healthPacksCollected;
    public int currentAmo = 50;
    [SerializeField] public Text healthPackText;
    [SerializeField] public Text AmmoText;
    private AudioSource playerAudio;
    [SerializeField] private AudioClip equipHealthPack;

    public void IncrementHealthPacksCollected() {

        playerAudio.PlayOneShot(equipHealthPack);
        healthPacksCollected += 1;
    }

    public void DecrementHealthPacksCollected()
    {
        healthPacksCollected -= 1;
    }

    public void IncrementAmmo()
    {
        currentAmo += Random.Range(30, 81);
    }

    public void DecrementAmmo()
    {
        currentAmo -= 1;
    }

    public void RefreshHealthPacks()
    {
        healthPackText.text = "X " + healthPacksCollected.ToString();
    }

    public void RefreshAmmoText()
    {
        AmmoText.text = "X " + currentAmo.ToString();
    }

    void Update()
    {
        RefreshHealthPacks();
        RefreshAmmoText();
    }

    private void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }
}
