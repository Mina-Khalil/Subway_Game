using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManger : MonoBehaviour {
    public Sound[] sounds;
    public static bool ismute =false;
    void Start()
    {
        
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
        }
        if(ismute==false)
        {
            PlaySound("Main Theme");
            foreach (Sound s in sounds)
            {
                s.source.mute = false;
            }
        }
    }
    public void PlaySound(string name)
    {
        foreach(Sound s in sounds)
        {
            if (s.name == name)
                s.source.Play();
        }
    }
    public void muite()
    {
        if (ismute == false)
        {
            foreach (Sound s in sounds)
            {
                    s.source.mute = true;
            }
            ismute = true;
        }
        else
        {
            PlaySound("Main Theme");
            foreach (Sound s in sounds)
            {
                    s.source.mute = false;
            }
            ismute = false;
        }
    }
 
}
