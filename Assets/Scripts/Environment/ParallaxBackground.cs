using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    float length, startPos;
    [SerializeField] GameObject cam;
    [SerializeField] float parallaxEffect;
    [SerializeField] float movingVelocity = 0f;
    float starty = 0;
    float timer = 0f;
    void Start()
    {
        cam = Camera.main.gameObject;
        startPos = transform.position.x;
        length = GetComponentInChildren<SpriteRenderer>().bounds.size.x;
        starty = transform.position.y;
    }

    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startPos + dist + movingVelocity * timer, starty, transform.position.z);

        if (temp > startPos + length) startPos += length;
        else if (temp < startPos - length) startPos -= length;
    }
}
