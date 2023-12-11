using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public AudioSource gameOverSound;
    public AudioSource gemPickupSound;
    public AudioSource lockOpenSound;
    public AudioSource gameWinSound;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOverSound.Play();
            GameManager.isGameOver = true;
            gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("GreenGem"))
        {
            gemPickupSound.Play();
            GameManager.gemsCollected[0] = 1;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("YellowGem"))
        {
            gemPickupSound.Play();
            GameManager.gemsCollected[1] = 1;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("BlueGem"))
        {
            gemPickupSound.Play();
            GameManager.gemsCollected[2] = 1;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("LockYellow") && GameManager.keysCollected == 1)
        {
            lockOpenSound.Play();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("LockBlue") && GameManager.keysCollected == 2)
        {
            lockOpenSound.Play();
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Exit"))
        {
            GameManager.isWon = true;
            gameWinSound.Play();
        }
    }
}
