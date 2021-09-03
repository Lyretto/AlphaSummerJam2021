using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<GameObject> hearts = new List<GameObject>();
    public int lifes;
    public int maxLifes;

    private void Start()
    {
        maxLifes = hearts.Count;
        lifes = maxLifes;
    }
    public void ChangeLifes(int amount)
    {
        lifes += amount;
        hearts.ForEach((h) => h.SetActive( int.Parse(h.name) <= lifes));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Killzone"))
        {
            if (lifes <= 0)
                Debug.Log("Game over");
        }
        else
        {
            //TODO RESET POSITION
            ChangeLifes(-1);
        }
    }
}
