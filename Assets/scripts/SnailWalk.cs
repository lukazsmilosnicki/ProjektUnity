using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailWalk : MonoBehaviour
{
    AudioSource gameLostSound;
    public float speed = 4.0f;
    public GameObject exit;
    private Vector2 target;
    void Start()
    {
        gameLostSound = GetComponent<AudioSource>();
        target = new Vector2(exit.transform.position.x, transform.position.y);
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Exit"))
        {
            gameLostSound.Play();
            GameManager.isLost = true;
        }
    }
}
