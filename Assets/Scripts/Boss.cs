using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public Transform player;
    public bool isFlipped = false;
    // public int health = 200; // Set boss health
    public int damage = 1;
    public HealthBar playerHealth;

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision with player detected."); // Add this line for debugging
            playerHealth.TakeDamage(damage);
            if (playerHealth.health <= 0)
            {
                Destroy(gameObject); // This will destroy the player GameObject
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    // Commented-out methods for boss health and death
    // public void TakeDamage(int damage)
    // {
    //     health -= damage;
    //     if (health <= 0)
    //     {
    //         Die();
    //     }
    // }

    // void Die()
    // {
    //     Destroy(gameObject); // Or implement a death animation
    // }
}