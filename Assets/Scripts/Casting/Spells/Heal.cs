using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Casting.Spells
{
    public class Heal : MonoBehaviour
    {
        public int healedLifes = 2;
        //Heilt X Leben ( 2)
        void Start()
        {

            SpellBase sB = GetComponent<SpellBase>();
            sB.spellStartEvent.AddListener(StartSpell);
            sB.spellStartEvent.AddListener(StopSpell);
        }

        public void StartSpell()
        {
            SoundManager.Instance.PlayOneShot(SoundEvent.HEALSPELL);
            Player.Instance.ChangeLifes(healedLifes);
        }
        public void StopSpell()
        {

        }
    }
}