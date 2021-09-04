using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(!collision.transform.CompareTag("Enemy") && !collision.transform.CompareTag("Player")) Destroy(collision.gameObject);

        if (collision.transform.CompareTag("Enemy") && !collision.gameObject.GetComponent<Enemy>().freeze)
        {
            Destroy(collision.gameObject);
        }
    }
}
