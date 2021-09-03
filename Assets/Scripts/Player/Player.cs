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


    private static Player _instance;
    public static Player Instance { get { return _instance; } }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

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

    public void Die()
    {
        SoundManager.Instance.PlayOneShot(SoundEvent.DEATH);
        // TODO OPEN LOSE SCREEN 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Killzone"))
        {
            if (lifes <= 0)
            {
                Die();
            }
            else
            {
                transform.position = new Vector3(0f, 0f, 0f); // TODO SPawnPoint
                ChangeLifes(-1);
            }
        }
    }
}
