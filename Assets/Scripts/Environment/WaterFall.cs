using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFall : MonoBehaviour
{
    [SerializeField] GameObject waterFallEdge;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.CompareTag("Fire"))
        {
            Freezable frozenObj = waterFallEdge.GetComponent<Freezable>();
            if (frozenObj.freezed)
            {
                frozenObj.freezed = false;
                collision.gameObject.GetComponent<FireBall>().Explosion();
            }
            else
            {
                collision.gameObject.GetComponent<FireBall>().Explosion();
            }
            
        }

        if (collision.transform.CompareTag("Ice"))
        {
            Freezable frozenObj = waterFallEdge.GetComponent<Freezable>();
            if (frozenObj.freezed)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                frozenObj.freezed = true;
                Destroy(collision.gameObject);
            }

        }
    }
}
