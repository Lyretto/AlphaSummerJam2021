using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDoor : MonoBehaviour
{
    public Animator doorAnimator;

    private void OnEnable()
    {
        SoundManager.Instance.PlayOneShot(SoundEvent.OPENDOOR, (transform.position - Player.Instance.transform.position).sqrMagnitude < 10f ? 1f : 0.2f);
        doorAnimator.SetBool("Closed", false);
    }
    private void OnDisable()
    {
        SoundManager.Instance.PlayOneShot(SoundEvent.CLOSEDOOR, (transform.position - Player.Instance.transform.position).sqrMagnitude < 10f ? 1f : 0.2f);
        doorAnimator.SetBool("Closed", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // LEVEL GESCHAFFT
            //SceneManager.LoadScene("MainMenu");
            PlayerMovement.Instance.LevelDone(transform.position);
        }
    }
}
