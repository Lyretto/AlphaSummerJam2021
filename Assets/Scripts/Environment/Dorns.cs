using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dorns : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Player.Instance.ChangeLifes(-1);
        }
    }
}
