using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezable : MonoBehaviour
{
    public bool freezed;
    [SerializeField] BoxCollider2D boxCollider;
    SpriteRenderer freezeSr;
    SpriteRenderer waterfallSr;
    [SerializeField] Animator freezeAnimator;
    [SerializeField] Sprite unfreezedSprite;
    [SerializeField] Sprite freezedSprite;
    [SerializeField] GameObject waterfall;

    private void Start()
    {
        freezeSr = GetComponent<SpriteRenderer>();
        waterfallSr = waterfall.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (freezed)
        {
            freezeSr.color = new Color(0.8f, 0.8f, 1f, 1f);
            gameObject.layer = LayerMask.NameToLayer("Ground");
            waterfallSr.sprite = freezedSprite;
            freezeAnimator.enabled = false;
            boxCollider.enabled = true;
        } else
        { 
            freezeSr.color = new Color(0.6f, 0.6f, 1f, 0.4f);
            gameObject.layer = LayerMask.NameToLayer("Default");
            waterfallSr.sprite = unfreezedSprite;
            freezeAnimator.enabled = true;
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
