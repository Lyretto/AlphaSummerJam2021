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
    private SpriteRenderer sr;
    private bool invincable = false;
    private static Player _instance;
    public Transform spawnPoint = null;
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
        sr = GetComponent<SpriteRenderer>();
        maxLifes = hearts.Count;
        lifes = maxLifes;
        transform.position = spawnPoint.position;
    }
    public void ChangeLifes(int amount)
    {
        if(amount < 0)
        {
            if (!invincable)
            {
                lifes += amount;
                sr.color = new Color(0.4f, 0.05f, 0.05f, 1f);
                invincable = true;
                Invoke("ToggleHitMarker", 0.3f);
            }
        } else
            lifes += Mathf.Clamp(amount,0,maxLifes);

        if(lifes <= 0)
        {
            Die();
        }
        hearts.ForEach((h) => h.SetActive(int.Parse(h.name) <= lifes));
    }

    public void ToggleHitMarker()
    {
        invincable = false;
        sr.color = new Color(1f, 1f,1f, 1f);
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
            transform.position = spawnPoint?.position ?? Vector3.zero;
            invincable = false;
            ChangeLifes(-1);
        }
        if (collision.CompareTag("GroundKillzone"))
        {
            transform.position = spawnPoint?.position ?? Vector3.zero;
            invincable = false;
            ChangeLifes(-1);
        }
    }
}
