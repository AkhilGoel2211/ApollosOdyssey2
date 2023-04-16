using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int curHealth = 100;
    [SerializeField] private Slider enemyHealthBar;
    private Transform player;
    // Use this for initialization
    void Start()
    {
        enemyHealthBar.value = maxHealth;
        player = GameObject.Find("PlayerArmature").GetComponent<Transform>();
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
            PlayerScore score = player.GetComponent<PlayerScore>();
            score.incrementKills();
            Destroy(gameObject);
        }
    }
}