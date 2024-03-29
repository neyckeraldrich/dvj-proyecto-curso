﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 100;

    public GameObject deathEffect;
    public PlayerHealth player;

    public SpriteRenderer renderer;

    public void TakeDamage(int damage)
    {
        health -= damage;

        renderer.color = new Color(100 - health, 0, 0);

        if (health <= 0)
        {
            Die();

            FindObjectOfType<AudioManager>().Play("SoldierDeath");
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("SoldierHurt");
        }
    }

    void Die()
    {
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.name.Equals("Player"))
        {
            if (player != null)
            {
                player.TakeDamage(50);
            }
        }
    }
}