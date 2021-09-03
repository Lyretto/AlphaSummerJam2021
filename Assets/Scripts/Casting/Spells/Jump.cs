using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Casting.Spells
{
    public class Jump : MonoBehaviour
    {
        [SerializeField] float jumpForce = 1f;
        float maxJumpForce;
        [SerializeField] float buffTime = 5f;
        void Awake()
        {
            SpellBase sB = GetComponent<SpellBase>();
            sB.spellStartEvent.AddListener(StartSpell);
            maxJumpForce = PlayerMovement.Instance.jumpForce;
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
                PlayerMovement.Instance.jumpForce = maxJumpForce + jumpForce;
                if(buffTime <= 0)
                {
                    PlayerMovement.Instance.jumpForce = maxJumpForce;
                }
            }
        }
    }
}