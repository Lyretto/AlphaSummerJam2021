using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.Rendering.Universal;

namespace Assets.Scripts.Casting.Spells
{
    public class Heal : MonoBehaviour
    {
        public int healedLifes = 2;
        public SoundEvent onStart = SoundEvent.HEALSPELL;

        void Awake()
        {
            SpellBase sB = GetComponent<SpellBase>();
            sB.spellStartEvent.AddListener(StartSpell);
        }

        public void StartSpell()
        {
            SoundManager.Instance.PlayOneShot(onStart);
            Player.Instance.ChangeLifes(healedLifes);
            Destroy(this.gameObject);
        }
    }
}