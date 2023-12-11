using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBox : MonoBehaviour
{
    Collider2D myCollider;
    public AudioSource boxCreak;
    public AudioSource boxBreak;
    private void Start()
    {
        myCollider = GetComponent<Collider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DestroyAfterDelay());
        }
    }

    IEnumerator DestroyAfterDelay()
    {
        boxCreak.Play();
        yield return new WaitForSeconds(1.0f);
        boxBreak.Play();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        myCollider.enabled = false;
        
        yield return new WaitForSeconds(3.0f);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        myCollider.enabled = true;
    }
}
