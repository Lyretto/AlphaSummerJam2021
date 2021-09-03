using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    Vector3 mousePos;
    [HideInInspector] public UnityEvent onMouseButtonDown = new UnityEvent();
    public bool canMove = true;
    //[HideInInspector] public UnityEvent start

    private static InputManager _instance;
    public static InputManager Instance { get { return _instance; } }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
            onMouseButtonDown.Invoke();
        if (Input.GetKeyDown(KeyCode.Escape)) 
            UIManager.Instance.Pause();
    }

    public void CastSpell(UnityAction targetEvent)
    {
        canMove = false;
        onMouseButtonDown.AddListener(targetEvent);
    }
}
