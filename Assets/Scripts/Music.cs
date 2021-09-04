using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Music : MonoBehaviour
{
    private void Start()
    {
        if (FindObjectsOfType<Music>().ToList().Count <= 1)
            DontDestroyOnLoad(gameObject);
        else
            Destroy(gameObject);
    }
}
