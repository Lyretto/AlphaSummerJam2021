using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Casting.Spells
{
    public class FireBall : MonoBehaviour
    {

        [SerializeField] private float lifeTime = 3;
        [SerializeField] private float waitTime = 5;
        [SerializeField] private float speed = 4;
        private Vector3 target = new Vector3();
        private bool started = false;
        [SerializeField] private Sprite cursorFire;

        // Use this for initialization
        void Awake() {
            Debug.Log(target);
            SpellBase sB = GetComponent<SpellBase>();
            sB.spellStartEvent.AddListener(StartSpell);
            //sB.spellStartEvent.AddListener(StartSpell);
        }

        private void Update()
        {
            if (started)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.01f * speed);
            }
        }

        public void StartSpell()
        {
            Debug.Log("start Fireball");
            Destroy(this.gameObject, waitTime);
            //START Fireball waiting sound
            CancelInvoke();
            Cursor.SetCursor(cursorFire.texture, new Vector2(), CursorMode.ForceSoftware);
            //SET NEW CROSSHAIR
            InputManager.Instance.CastSpell(SetTarget);
        }

        public void SetTarget()
        {
            started = true;
            InputManager.Instance.onMouseButtonDown.RemoveListener(SetTarget);

            Cursor.SetCursor(cursorFire.texture, new Vector2(), CursorMode.ForceSoftware);

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