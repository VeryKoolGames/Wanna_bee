using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class KeyValuePairC {
    public string key;
    public AudioSource val;
}

public class AudioManager : MonoBehaviour
{
    public List<KeyValuePairC> MyList = new List<KeyValuePairC>();
    public static AudioManager Instance;
    private Dictionary<string, AudioSource> Sounds = new Dictionary<string, AudioSource>();

    private void Awake()
    {
        Instance = this;
        foreach (var kvp in MyList)
        {
            Sounds[kvp.key] = kvp.val;
        }
    }

    public void playSound(string soundName)
    {
        Sounds[soundName].Play();
    }
}