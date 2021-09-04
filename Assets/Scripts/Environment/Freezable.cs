using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezable : MonoBehaviour
{
    [SerializeField] bool freezed;
    [SerializeField] BoxCollider2D boxCollider;
    SpriteRenderer freezeSr;

    private void Start()
    {
        freezeSr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (freezed)
        {
            freezeSr.color = new Color(0.8f, 0.8f, 1f, 1f);
            gameObject.layer = LayerMask.NameToLayer("Ground");
            boxCollider.enabled = true;
        } else
        { 
            freezeSr.color = new Color(0.6f, 0.6f, 1f, 0.4f);
            gameObject.layer = LayerMask.NameToLayer("Default");
            boxCollider.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Ice"))
        {
            freezed = true;
            Destroy(collision.gameObject);
        }

        if (collision.transform.CompareTag("Fire"))
        {
            freezed = false;
            collision.GetComponent<FireBall>().Explosion();
        }
    }
}
