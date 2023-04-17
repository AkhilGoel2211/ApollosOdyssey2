using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int curHealth = 100;
    [SerializeField] private Slider enemyHealthBar;
    private Transform player;
    private AudioSource terrianAudio;
    [SerializeField] private AudioClip enemyDeathSound;
    // Use this for initialization
    void Start()
    {
        enemyHealthBar.value = maxHealth;
        player = GameObject.Find("PlayerArmature").GetComponent<Transform>();
        terrianAudio = GameObject.Find("Terrain").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        AdjustCurrentHealth(0);
        enemyHealthBar.value = curHealth;
    }

    public void AdjustCurrentHealth(int adj)
    {
        curHealth += adj;
        if (curHealth <= 0)
        {
            terrianAudio.PlayOneShot(enemyDeathSound);
            PlayerScore score = player.GetComponent<PlayerScore>();
            score.incrementKills();
            Destroy(gameObject);
        }
    }
}