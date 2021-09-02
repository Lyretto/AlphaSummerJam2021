using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> SpellPrefabs;
    [SerializeField] private Text CastLeftText;
    [SerializeField] private GameObject SpellMenu;
    public int letters = 50;
    // Start is called before the first frame update
    private static SpellManager _instance;
    public static SpellManager Instance { get { return _instance; } }

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

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && !SpellMenu.activeSelf)
        {
            UpdateLettersLeft();
            StartSpell();
        }
    }

    public void StartSpell()
    {
        ToggleMenu();
    }

    public void TryCastSpell(string spellName)
    {
        GameObject possibleSpell = SpellPrefabs?.Find((spell) => spell.name == spellName) ?? null;
        
        if(possibleSpell != null)
        {
            letters -= spellName.Length;
            Instantiate(possibleSpell, new Vector3(0f,0f,0f), Quaternion.identity);
        }
        else
        {
            SoundManager.Instance.PlayOneShot(SoundEvent.SPELLFAILED);
        }
        ToggleMenu();
    }

    public void UpdateLettersLeft(int actuelLength = 0)
    {
        CastLeftText.text = "Letters left: " + (letters - actuelLength).ToString();
    }

    public void ToggleMenu()
    {
        SpellMenu.SetActive(!SpellMenu.activeSelf);
    }
}