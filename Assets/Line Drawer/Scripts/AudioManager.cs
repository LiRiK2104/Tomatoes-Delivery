using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _soundSource;
    [SerializeField] private AudioSource _soundClick;

    public AudioClip[] clips = new AudioClip[5];

    public Dictionary<SoundFX, AudioClip> sounds = new Dictionary<SoundFX, AudioClip>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        sounds = new Dictionary<SoundFX, AudioClip>
        {
            { SoundFX.push, clips[0] },
            { SoundFX.hold, clips[1] },
            { SoundFX.tomatoSpawn, clips[2] },
            { SoundFX.win, clips[3] },
            { SoundFX.fullWin, clips[4] }
        };
    }

    private void Start()
    {
        _musicSource.Play();
    }

    public void PlaySound(SoundFX fx)
    {
        _soundSource.clip = sounds[fx];
        _soundSource.Play();
    }

    public void PlayClick()
    {
        _soundClick.Play();
    }
}

public enum SoundFX
{
    push,
    tomatoSpawn,
    hold,
    win,
    fullWin
}
