using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 3;

    void Start()
    {
        health = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        if (health > 0)
            health -= damage;
    }
}