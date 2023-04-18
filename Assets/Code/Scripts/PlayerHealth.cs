using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	public static event Action OnPlayerDeath;
	public int maxHealth = 100;
	public int currentHealth;
	private float timeOfLastRadiation;
	private float radiationDelta = 60 * 7;
	public HealthBar healthBar;
	private AudioSource playerAudioSource;
	[SerializeField] private AudioClip radiationSoundEffect;
	private LeaderboardManager scoreManager;
	private PlayerScore playerScore;
	[SerializeField] private GameObject gameOverMenu;
	private bool scoreAdded = false;

	// Start is called before the first frame update
	void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
		playerAudioSource = GetComponent<AudioSource>();
		scoreManager = GameObject.Find("Terrain").GetComponent<LeaderboardManager>();
		playerScore = GetComponent<PlayerScore>();
    }

    // Update is called once per frame
    void Update()
    {
		if(currentHealth <= 0)
        {
			currentHealth = 0;
            if (!scoreAdded)
            {
				scoreManager.AddScore(playerScore.getKills());
				scoreAdded = true;
			}
			gameOverMenu.SetActive(true);
        }

		if(Time.time > timeOfLastRadiation + radiationDelta)
        {
			currentHealth -= 20;
			timeOfLastRadiation = Time.time;
			playerAudioSource.PlayOneShot(radiationSoundEffect);
        }
		healthBar.SetHealth(currentHealth);
    }

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);
	}
}
