using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Casting.Spells
{
    public class Heal : MonoBehaviour
    {
        public int healedLifes = 2;
        //Heilt X Leben ( 2)
        void Awake()
        {

            SpellBase sB = GetComponent<SpellBase>();
            sB.spellStartEvent.AddListener(StartSpell);
        }

        public void StartSpell()
        {
            SoundManager.Instance.PlayOneShot(SoundEvent.HEALSPELL);
            healing();
            Destroy(this.gameObject);
        }

        public void healing()
        {
            if (Player.Instance.lifes + healedLifes <= Player.Instance.maxLifes)
                Player.Instance.ChangeLifes(healedLifes);
            else if (Player.Instance.lifes + healedLifes > Player.Instance.maxLifes)
                Player.Instance.ChangeLifes(Player.Instance.maxLifes - Player.Instance.lifes);

        }
    }
}