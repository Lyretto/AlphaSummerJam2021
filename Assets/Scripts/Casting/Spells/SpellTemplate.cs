using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Casting.Spells
{
    public class SpellTemplate : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

            SpellBase sB = GetComponent<SpellBase>();
            sB.spellStartEvent.AddListener(StartSpell);
            sB.spellStartEvent.AddListener(StopSpell);
        }

        public void StartSpell()
        {

        }
        public void StopSpell()
        {

        }
    }
}