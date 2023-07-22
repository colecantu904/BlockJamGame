using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class audioManage : MonoBehaviour
{
    public sound[] sounds;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (sound s in sounds)
        {
            s.audios = gameObject.AddComponent<AudioSource>();
            s.audios.clip = s.audio;

            s.audios.volume = s.volume;
            s.audios.loop = s.loop;
        }
    }

    public void play(string name)
    {
        sound s = Array.Find(sounds, sound => sound.name == name);
        s.audios.Play();
    }
}
