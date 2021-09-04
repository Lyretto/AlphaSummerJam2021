using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    Animator torchAnimator;
    public List<GameObject> objectsToDeactivate = new List<GameObject>();
    private GameObject light;

    private void Start()
    {
        torchAnimator = GetComponent<Animator>();
        torchAnimator.SetBool("isBurning", false);
        light = gameObject.transform.GetChild(0).GetComponent<Transform>().gameObject;
        light.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Fire"))
        {
            if (!light.activeSelf)
            {
                Activate();
                collision.gameObject.GetComponent<FireBall>().Explosion();
            }
        }
    }

    public void Activate()
    {
        objectsToDeactivate.ForEach((o) => o.SetActive(!o.activeSelf));
        light.SetActive(true);
        torchAnimator.SetBool("isBurning", true);
    }

    public void Dectivate()
    {
        objectsToDeactivate.ForEach((o) => o.SetActive(!o.activeSelf));
        light.SetActive(false);
        torchAnimator.SetBool("isBurning", false);
    }

}
