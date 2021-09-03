using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoveablePlatform : MonoBehaviour
{
    [SerializeField] private float speed = 0.03f;
    public List<GameObject> points = new List<GameObject>();
    public GameObject nextPoint;
    private Rigidbody2D rb;

    private void Start()
    {
        nextPoint = points.First();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if ( Vector3.Distance(transform.position, nextPoint.transform.position) != 0f)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPoint.transform.position, speed);
        }
        else 
        {
            nextPoint = points.Where((p) => p != nextPoint).ToArray()[Random.Range(0, points.Count - 1)];
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        col.gameObject.transform.SetParent(gameObject.transform, true);
    }
    void OnCollisionExit2D(Collision2D col)
    {
        col.gameObject.transform.parent = null;
    }
}
