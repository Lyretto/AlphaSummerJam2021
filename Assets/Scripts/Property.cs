using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Property : MonoBehaviour
{
    [SerializeField] private bool effectedByGravity = false;
    [HideInInspector] public UnityEvent HitByGravity;
    [SerializeField] private bool effectedByFire = false;
    [HideInInspector] public UnityEvent HitByFire;
    [SerializeField] private bool effectedByIce = false;
    [HideInInspector] public UnityEvent HitByIce;

    private void Start()
    {
        HitByGravity.AddListener(LooseGravity);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (effectedByGravity && collision.transform.CompareTag("Gravity"))
        {
            HitByGravity.Invoke();
            Destroy(collision.gameObject);
        }

        if (effectedByFire && collision.transform.CompareTag("Fire"))
        {
            HitByFire.Invoke();
            collision.GetComponent<FireBall>().Explosion();
        }

        if (effectedByIce && collision.transform.CompareTag("Ice"))
        {
            HitByIce.Invoke();
            Destroy(collision.gameObject);
        }
    }

    public void LooseGravity()
    {
        GetComponent<Rigidbody2D>().gravityScale = GetComponent<Rigidbody2D>().gravityScale * -1;
    }
}
