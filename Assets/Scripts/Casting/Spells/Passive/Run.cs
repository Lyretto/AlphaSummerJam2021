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
        }

        public void StartSpell()
        {

        }

        private void Update()
        {
            if (buffTime >= 0)
            {
                buffTime -= Time.deltaTime;
                PlayerMovement.Instance.movementSpeed +=  speedMultiplier;
                if (buffTime <= 0)
                {
                    PlayerMovement.Instance.movementSpeed -= speedMultiplier;
                }
            }
        }
    }
}