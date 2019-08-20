using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int lives = 3;
    public int health = 100;

    public GameObject deathEffect;
    public GameObject startPosition;

    public TMPro.TextMeshProUGUI livesCounter;


    public void TakeDamage(int damage)
    {
        health -= damage;

        Debug.Log("Player Health " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
		
		
		// Reduce lives counter in UI
			this.lives--;
			livesCounter.text = lives.ToString();
		
		if (this.lives < 1){
			SceneManager.LoadScene(4);
		} else {
			
			
			// Move to starting position
			this.transform.position = startPosition.transform.position;
			
			// Reset Health
			health = 100;
		}
		
    }
}
