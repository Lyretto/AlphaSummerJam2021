using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Casting.Spells
{
    public class Rockball : MonoBehaviour
    {

        [SerializeField] private float lifeTime = 3;
        [SerializeField] private float waitTime = 5;
        [SerializeField] private float speed = 4;
        private Vector3 target = new Vector3();
        private bool started = false;
        [SerializeField] private Sprite cursorFire;

        // Use this for initialization
        void Awake() {
            SpellBase sB = GetComponent<SpellBase>();
            sB.spellStartEvent.AddListener(StartSpell);
        }

        private void FixedUpdate()
        {
            Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3 lookAt = mouseScreenPosition;

            float AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);

            float AngleDeg = (180 / Mathf.PI) *AngleRad;

            this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);

            if (started)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.01f * speed);
            }
        }

        public void StartSpell()
        {
            Destroy(this.gameObject, waitTime);
            //START Fireball waiting sound
            CancelInvoke();
            //Cursor.SetCursor(cursorFire.texture, new Vector2(), CursorMode.ForceSoftware);
            InputManager.Instance.CastSpell(SetTarget);
        }

        public void SetTarget()
        {
            started = true;
            InputManager.Instance.onMouseButtonDown.RemoveListener(SetTarget);
            InputManager.Instance.canMove = true;
            //Cursor.SetCursor(cursorFire.texture, new Vector2(), CursorMode.ForceSoftware);

            Destroy(this.gameObject, lifeTime);
            // Stop Fireball waiting sound
            // Activate Fireball MOVING Sound
        }

        //DESTROY ON COLLISION
        private void OnDestroy()
        {
            SoundManager.Instance.PlayOneShot(SoundEvent.FIREBALLHITTING);
        }
    }
}