using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpellBase : MonoBehaviour
{
    public UnityEvent spellStartEvent = new UnityEvent();
    public UnityEvent spellEndEvent = new UnityEvent();

    void Start()
    {
        spellStartEvent.Invoke();
    }
}
