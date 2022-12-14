using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour {

    public AudioMixer audioMixer;
    public AudioMixer audioMixerBgSound;

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void SetVolumeBg (float volume)
    {
        audioMixerBgSound.SetFloat("bgvolume", volume);
    }

}
