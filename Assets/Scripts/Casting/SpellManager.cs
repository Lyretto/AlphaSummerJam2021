using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellManager : MonoBehaviour
{
    List<GameObject> SpellPrefabs;
    [SerializeField] private Text CastLeftText;
    private int letters;
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
        letters = 5;
    }

    public void TryCastSpell(string spellName)
    {
        GameObject possibleSpell = SpellPrefabs?.Find((spell) => spell.name == spellName) ?? null;
        

        if(possibleSpell != null)
        {
            letters = -spellName.Length;
        }
        else
        {
            // PLAY
        }
    }
    public void UpdateLettersLeft(int actuelLength = 0)
    {
        CastLeftText.text = "Letters left: " + (letters - actuelLength).ToString(); ;
    }

}
