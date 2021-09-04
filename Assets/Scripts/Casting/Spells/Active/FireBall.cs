using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class FireBall : MonoBehaviour
{

    [SerializeField] private float lifeTime = 3;
    [SerializeField] private float waitTime = 5;
    [SerializeField] private float speed = 4;
    private bool started = false;
    bool ended;

    // Use this for initialization
    void Awake() {
        SpellBase sB = GetComponent<SpellBase>();
        sB.spellStartEvent.AddListener(StartSpell);
    }

    private void FixedUpdate()
    {
        if (ended) return;
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
        //START Fireball waiting sound
        CancelInvoke();
        //Cursor.SetCursor(cursorFire.texture, new Vector2(), CursorMode.ForceSoftware);
        InputManager.Instance.CastSpell(SetTarget);
        SoundManager.Instance.FireBallSound.SetActive(true);
    }

    public void SetTarget()
    {
        started = true;
        InputManager.Instance.onMouseButtonDown.RemoveListener(SetTarget);
        Destroy(this.gameObject, lifeTime);
    }

    public void Explosion()
    {
        ended = true;
        GetComponentInChildren<Animator>().SetTrigger("Explosion");
        Destroy(this.gameObject, 0.6f);
        SoundManager.Instance.FireBallSound.SetActive(false);
        SoundManager.Instance.PlayOneShot(SoundEvent.FIREBALLHITTING);
    }

    private void OnDestroy()
    {
        SoundManager.Instance.FireBallSound.SetActive(false);
    }
}
