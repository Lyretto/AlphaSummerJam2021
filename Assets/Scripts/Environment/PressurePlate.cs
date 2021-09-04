using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    public List<GameObject> objectsToDeactivate = new List<GameObject>();
    private int onPlate = 0;
    private SpriteRenderer sr;
    public Sprite enabledSprite;
    public Sprite disabledSprite;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") || collision.transform.CompareTag("Rock") || collision.transform.CompareTag("Enemy"))
        {
            onPlate++;
            Activate();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") || collision.transform.CompareTag("Rock") || collision.transform.CompareTag("Enemy"))
        {
            onPlate--;
            if(onPlate <= 0)
            {
                Deactivate();
            }
        }
    }
    public void Activate()
    {
        objectsToDeactivate.ForEach((o) => o.SetActive(!o.activeSelf));
        sr.sprite = enabledSprite;
    }

    public void Deactivate()
    {
        objectsToDeactivate.ForEach((o) => o.SetActive(!o.activeSelf));
        sr.sprite = disabledSprite;
    }

}
