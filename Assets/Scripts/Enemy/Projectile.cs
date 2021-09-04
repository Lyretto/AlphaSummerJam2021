using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 7f;
    [SerializeField] int damage = 1;
    Rigidbody2D bulletRb;
    Vector3 target;
    Vector3 start;

    private void Start()
    {
        target = Player.Instance.transform.position;
        start = transform.position;
        bulletRb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
        if (collision.transform.tag != "Player" && collision.transform.tag != "Enemy") Destroy(this.gameObject);

        if (collision.transform.CompareTag("Player"))
        {
            Player.Instance.ChangeLifes(-damage);
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Kollision");
        if (!collision.transform.CompareTag("Player") && !collision.transform.CompareTag("Enemy")) Destroy(this.gameObject);

        if (collision.transform.CompareTag("Player"))
        {
            Player.Instance.ChangeLifes(-damage);
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, Player.Instance.transform.position, bulletSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, target, bulletSpeed * Time.deltaTime);
        if (transform.position == target) Destroy(this.gameObject);
        
    }
}
