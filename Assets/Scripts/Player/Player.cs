using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public List<GameObject> hearts = new List<GameObject>();
    public int lifes;
    public int maxLifes;
    public GameObject HitMarker;


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

        if (amount < 0)
        {
            ToggleHitMarker();
            Invoke("ToggleHitMarker",0.1f);
        }
        if(lifes < 0)
        {
            Die();
        }

    }

    public void ToggleHitMarker()
    {
        HitMarker.SetActive(!HitMarker.activeSelf);
    }

    public void Die()
    {
        SoundManager.Instance.PlayOneShot(SoundEvent.DEATH);
        SceneManager.LoadScene("MainMenu");
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
