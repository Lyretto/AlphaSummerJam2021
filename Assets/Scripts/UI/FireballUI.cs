using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballUI : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    Vector3 newTarget = new Vector3();
    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1;
        SetnewTarget();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, newTarget, 0.01f * speed);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, 
            Quaternion.LookRotation(Vector3.forward, newTarget - transform.position) * Quaternion.Euler(0, 0, 90), speed);

        if (newTarget == transform.position)
            SetnewTarget();
    }

    private void SetnewTarget()
    {
        newTarget = new Vector3(Random.Range(0f, 1920f),Random.Range(0f, 1080f), 0);
        newTarget = new Vector3(Camera.main.ScreenToWorldPoint(newTarget).x, Camera.main.ScreenToWorldPoint(newTarget).y, 0f);

    }
}
