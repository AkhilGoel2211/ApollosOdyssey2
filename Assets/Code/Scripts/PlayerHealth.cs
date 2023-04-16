using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth;
	private float timeOfLastRadiation;
	private float radiationDelta = 60 * 7;
	public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
		if(currentHealth <= 0)
        {
			currentHealth = 0;
        }

		if(Time.time > timeOfLastRadiation + radiationDelta)
        {
			currentHealth -= 20;
			timeOfLastRadiation = Time.time;
        }
    }

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);
	}
}
