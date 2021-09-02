using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Casting.Spells
{
    public class FireBall : MonoBehaviour
    {
        private GameObject target = null;
        [SerializeField] private static float speed = 4;

        // Use this for initialization
        void Start() {

            SpellBase sB = GetComponent<SpellBase>();
            sB.spellStartEvent.AddListener(StartSpell);
            //sB.spellStartEvent.AddListener(StartSpell);
        }

        private void Update()
        {
            if (target)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, 0.01f * speed);
            }
        }

        public void StartSpell()
        {
            //START Fireball waiting
            // TELL PLAYER TO SHOOT
        }

        public void SetTarget(GameObject target)
        {
            // Stop Fireball waiting sound
            // Activate Fireball MOVING Sound
            this.target = target;
        }

        //DESTROY ON COLLISION
        private void OnDestroy()
        {
            SoundManager.Instance.PlayOneShot(SoundEvent.FIREBALLHITTING);
        }
    }
}