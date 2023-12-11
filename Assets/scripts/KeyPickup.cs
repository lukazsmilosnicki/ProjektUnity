using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    private int collisionCount = 0;
    public AudioSource pickupSound;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collisionCount++;
            if (collisionCount == 1)
            {
                pickupSound.Play();
                Destroy(gameObject);
                GameManager.keysCollected += 1;
            }
        }
    }
}
