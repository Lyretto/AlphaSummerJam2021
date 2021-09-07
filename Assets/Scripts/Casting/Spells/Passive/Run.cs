using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Casting.Spells
{
    public class Run : MonoBehaviour
    {
        [SerializeField] float speedMultiplier = 2f;
        [SerializeField] float buffTime = 5f;

        void Awake()
        {
            SpellBase sB = GetComponent<SpellBase>();
            sB.spellStartEvent.AddListener(StartSpell);
            Invoke("StopSpell", buffTime);
        }

        public void StartSpell()
        {
            PlayerMovement.Instance.movementSpeed += speedMultiplier;
        }

        public void StopSpell()
        {
            PlayerMovement.Instance.movementSpeed -= speedMultiplier;
            Destroy(this.gameObject);
        }
    }
}