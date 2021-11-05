using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Casting.Spells
{
    public class Gravity : MonoBehaviour
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
            if (started)
            {
                Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Vector3 lookAt = mouseScreenPosition;

                float AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);

                float AngleDeg = (180 / Mathf.PI) * AngleRad;

                this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
                this.transform.position = Vector3.MoveTowards(this.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.01f * speed);
            }
            else
            {
                transform.position = PlayerMovement.Instance.transform.position;
            }
        }

        public void StartSpell()
        {
            Destroy(this.gameObject, waitTime);
            CancelInvoke();
            InputManager.Instance.CastSpell(SetTarget);
        }

        public void SetTarget()
        {
            started = true;
            InputManager.Instance.onMouseButtonDown.RemoveListener(SetTarget);

            Destroy(this.gameObject, lifeTime);
        }

        private void OnDestroy()
        {
            SoundManager.Instance.PlayOneShot(SoundEvent.FIREBALLHITTING);
        }
    }
}