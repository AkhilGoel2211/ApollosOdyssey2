using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public int healthPacksCollected;
    public int superPowerUp;
    [SerializeField] public Text healthPackText;
    [SerializeField] public Text superPowerUpText;
    

    public void IncrementHealthPacksCollected() {
        healthPacksCollected += 1;
    }

    public void DecrementHealthPacksCollected()
    {
        healthPacksCollected -= 1;
    }

    public void IncrementSuperPowerUp()
    {
        superPowerUp += 1;
    }

    public void DecrementSuperPowerUp()
    {
        superPowerUp -= 1;
    }

    public void RefreshHealthPacks()
    {
        healthPackText.text = "X " + healthPacksCollected.ToString();
    }

    public void RefreshSuperPowerUpText()
    {
        superPowerUpText.text = "X" + superPowerUp.ToString();
    }

    void Update()
    {
        RefreshHealthPacks();
        RefreshSuperPowerUpText();
    }
}
