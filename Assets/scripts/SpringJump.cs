using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SpringJump : MonoBehaviour
{
    public Animator springAnimator;
    Collision2D collision2D;
    AudioSource audioSource;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision2D = collision;
            audioSource = gameObject.GetComponent<AudioSource>();
            StartCoroutine(ActivateSpring());
        }
    }

    IEnumerator ActivateSpring()
    {
        Rigidbody2D player = collision2D.gameObject.GetComponent<Rigidbody2D>();
        audioSource.Play();
        player.AddForce(new Vector2(0f, 750));
        springAnimator.SetBool("isRetracted", false);
        yield return new WaitForSeconds(0.5f);
        springAnimator.SetBool("isRetracted", true);
    }
}
