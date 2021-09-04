using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDoor : MonoBehaviour
{
    public Animator doorAnimator;

    private void OnEnable()
    {
        doorAnimator.SetBool("Closed", false);
    }
    private void OnDisable()
    {
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
