using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerScore : MonoBehaviour
{
    public Text counterText;
    private int killCount;
    // Start is called before the first frame update
    void Start()
    {
        killCount = 0;
        counterText.text = killCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        refreshKills();
    }

    public void incrementKills()
    {
        killCount += 1;
    }

    public void refreshKills()
    {
        counterText.text = killCount.ToString();
    }
}
