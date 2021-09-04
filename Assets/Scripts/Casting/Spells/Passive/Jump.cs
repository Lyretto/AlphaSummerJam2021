using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Casting.Spells
{
    public class Jump : MonoBehaviour
    {
        [SerializeField] float jumpForce = 1f;
        [SerializeField] float buffTime = 5f;
        void Awake()
        {
            SpellBase sB = GetComponent<SpellBase>();
            sB.spellStartEvent.AddListener(StartSpell);
        }

        public void StartSpell()
        {

        }
        public void StopSpell()
        {

        }

        private void Update()
        {
            if(buffTime >= 0)
            {
                buffTime -= Time.deltaTime;
                PlayerMovement.Instance.jumpForce +=  jumpForce;
                if(buffTime <= 0)
                {
                    PlayerMovement.Instance.jumpForce -= jumpForce;
                }
            }
        }
    }
}