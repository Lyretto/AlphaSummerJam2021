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
            Invoke("StopSpell", buffTime);
        }

        public void StartSpell()
        {
            PlayerMovement.Instance.jumpForce += jumpForce;
        }
        public void StopSpell()
        {
            PlayerMovement.Instance.jumpForce -= jumpForce;
            Destroy(this.gameObject);
        }
    }
}