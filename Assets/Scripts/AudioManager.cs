using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    public AudioMixerGroup mixerGroup;

    public Sound[] sounds;


    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.mixerGroup;
        }
    }

    public void Play(string _sound)
    {
        Sound sound = PrepareSound(_sound);
        sound.source.Play();
    }

    public void PlayDelayed(string _sound, float delay)
    {
        Sound sound = PrepareSound(_sound);
        sound.source.PlayDelayed(delay);
    }

    private Sound PrepareSound(string _sound)
    {
        Sound sound = Array.Find(sounds, item => item.name == _sound);
        sound.source.volume = sound.volume * (1f + UnityEngine.Random.Range(-sound.volumeVariance / 2f, sound.volumeVariance / 2f));
        sound.source.pitch = sound.pitch * (1f + UnityEngine.Random.Range(-sound.pitchVariance / 2f, sound.pitchVariance / 2f));
        return sound;
    }

    public void Stop(string _sound)
    {
        Sound sound = Array.Find(sounds, item => item.name == _sound);
        if (sound == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        sound.source.Stop();
    }
}
