using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject doorClosed;
    public GameObject doorOpen;
    public GameObject leverActivated;
    public AudioSource leverSound;

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameManager.keyPressed = false;

        if (Input.GetKey(KeyCode.E))
        {
            GameManager.keyPressed = true;
            leverSound.Play();
            doorClosed.SetActive(false);
            doorOpen.SetActive(true);
            leverActivated.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
