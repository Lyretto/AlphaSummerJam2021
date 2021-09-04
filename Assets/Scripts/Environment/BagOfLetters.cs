using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagOfLetters : MonoBehaviour
{
    [SerializeField] int MIN_LETTERS;
    [SerializeField] int MAX_LETTERS;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            SpellManager.Instance.Addletters(Random.Range(MIN_LETTERS, MAX_LETTERS));
            Destroy(this.gameObject);
        }
    }
}
