using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAble : MonoBehaviour
{
    public bool isDestroyAble = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isDestroyAble)
            Destroy(this.gameObject);
    }
}
