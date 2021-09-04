using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Casting.Spells
{
    public class Rockball : MonoBehaviour
    {
        private bool started = false;
        Rigidbody2D rb;
        public float force = 60f;

        // Use this for initialization
        void Awake() {
            SpellBase sB = GetComponent<SpellBase>();
            sB.spellStartEvent.AddListener(StartSpell);
            rb = GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Kinematic;
        }

        private void FixedUpdate()
        {

            if(!started)
            {
                Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Vector3 lookAt = mouseScreenPosition;

                float AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);

                float AngleDeg = (180 / Mathf.PI) * AngleRad;

                this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);

                transform.position = PlayerMovement.Instance.transform.position;
            }
        }

        public void StartSpell()
        {
            InputManager.Instance.CastSpell(SetTarget);
            PlayerMovement.Instance.jumpForce = 2.5f;
        }

        public void SetTarget()
        {
            PlayerMovement.Instance.jumpForce = 7.5f;
            InputManager.Instance.onMouseButtonDown.RemoveListener(SetTarget);
            rb.bodyType = RigidbodyType2D.Dynamic;
            Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            GetComponent<BoxCollider2D>().isTrigger = false;
            Vector3 angle = Vector3.Normalize(direction);
            rb.AddForce(angle * force, ForceMode2D.Impulse);
            transform.position += angle;
            
            started = true;
        }

        //DESTROY ON COLLISION
        private void OnDestroy()
        {

        }
    }
}