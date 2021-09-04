using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> SpellPrefabs;
    [SerializeField] private List<Text> CastLeftText;
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
        Time.timeScale = 1;
    }

    private void Start()
    {
        CastLeftText.ForEach(t => t.text = letters.ToString());
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && !SpellMenu.activeSelf)
        {
            UpdateLettersLeft();
            StartSpell();
            Time.timeScale = 0;
        }
    }

    public void StartSpell()
    {
        ToggleMenu();
    }

    public void TryCastSpell(string spellName)
    {
        GameObject possibleSpell = SpellPrefabs?.Find((spell) => spell.name.ToUpper() == spellName) ?? null;
        
        if(possibleSpell != null)
        {
            letters -= spellName.Length;
            Instantiate(possibleSpell, PlayerMovement.Instance.transform.position + Vector3.right, Quaternion.identity);
            SoundManager.Instance.PlayOneShot(SoundEvent.SPELLSUCCESS);
        }
        else
        {
            SoundManager.Instance.PlayOneShot(SoundEvent.SPELLFAILED);
        }
        Time.timeScale = 1;
        ToggleMenu();
    }

    public void UpdateLettersLeft(int actuelLength = 0)
    {
        CastLeftText.ForEach(t => t.text = (letters - actuelLength).ToString());
    }

    public void ToggleMenu()
    {
        SpellMenu.SetActive(!SpellMenu.activeSelf);
    }
}