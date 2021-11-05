using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    Animator torchAnimator;
    public List<GameObject> objectsToDeactivate = new List<GameObject>();
    private GameObject light;
    public bool isActivated = false;

    private void Start()
    {
        torchAnimator = GetComponent<Animator>();
        torchAnimator.SetBool("isBurning", false);
        light = gameObject.transform.GetChild(0).GetComponent<Transform>().gameObject;
        light.SetActive(isActivated);
        torchAnimator.SetBool("isBurning", isActivated);
        GetComponent<Property>().HitByFire.AddListener(Activate);
        GetComponent<Property>().HitByIce.AddListener(Deactivate);
    }

    public void Activate()
    {
        objectsToDeactivate.ForEach((o) => o.SetActive(!o.activeSelf));
        light.SetActive(true);
        torchAnimator.SetBool("isBurning", true);
    }

    public void Deactivate()
    {
        objectsToDeactivate.ForEach((o) => o.SetActive(!o.activeSelf));
        light.SetActive(false);
        torchAnimator.SetBool("isBurning", false);
    }

}
