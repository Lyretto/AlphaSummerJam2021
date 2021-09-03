using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public List<GameObject> objectsToDeactivate = new List<GameObject>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Fire")) { 
            Activate();
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Fire"))
        {
            Activate();
            Destroy(collision.gameObject);
        }
    }


    public void Activate()
    {
        //Set Other Sprite and disable Fog/enable Light

        //Example Deactive Platform
        objectsToDeactivate.ForEach((o) => o.SetActive(false));
    }

    public void Dectivate()
    {
        //Set Other Sprite and disable Fog/enable Light

        //Example Deactive Platform
        objectsToDeactivate.ForEach((o) => o.SetActive(true));
    }

}
