using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum SoundEvent
{
    SPELLFAILED, FIREBALLHITTING, ICEBALLHITTING, HEALSPELL, DEATH, SPELLSUCCESS
}

public class SoundManager : MonoBehaviour
{
    public AudioLayout audioClips;

    private static SoundManager _instance;
    public static SoundManager Instance { get { return _instance; } }
    
    public bool fmod = true;

    public GameObject FireBallSound;

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
    public void PauseSounds(bool paused)
    {
        RuntimeManager.PauseAllEvents(paused);
    }

    public bool PlayOneShot(SoundEvent soundEvent, float volume = 1.0f)
    {
        if (fmod)
        {
            string eventName = audioClips.events.FirstOrDefault(a => a.soundEvent == soundEvent).eventName;
            if (eventName == null) return false;

            RuntimeManager.PlayOneShot(eventName);
        }
        return true;
    }
}

[System.Serializable]
public class AudioLayout
{
    [System.Serializable]
    public struct audioEvents
    {
        public SoundEvent soundEvent;
        public string eventName;
    }
    public List<audioEvents> events = new List<audioEvents>();
}


