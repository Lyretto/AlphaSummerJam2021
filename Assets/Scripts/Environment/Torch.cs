using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    Animator torchAnimator;
    public List<GameObject> objectsToDeactivate = new List<GameObject>();
    GameObject light;

    private void Start()
    {
        torchAnimator = GetComponent<Animator>();
        torchAnimator.SetBool("isBurning", false);
        light = gameObject.transform.GetChild(0).GetComponent<Transform>().gameObject;
        light.SetActive(false);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.transform.CompareTag("Fire")) { 
    //        Activate();
    //        Destroy(collision.gameObject);
    //    }
    //}

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
        light.SetActive(true);
        torchAnimator.SetBool("isBurning", true);
    }

    public void Dectivate()
    {
        //Set Other Sprite and disable Fog/enable Light

        //Example Deactive Platform
        objectsToDeactivate.ForEach((o) => o.SetActive(true));
        light.SetActive(false);
        torchAnimator.SetBool("isBurning", false);
    }

}
