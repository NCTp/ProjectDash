using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static AudioClip fireSound;
    public static AudioClip dashSound;
    public static AudioClip dashAttackSound;
    public static AudioClip magicianBossBG;
    static AudioSource audioSrc;
    
	void Start () {
        fireSound = Resources.Load<AudioClip>("Magic_1");
        dashSound = Resources.Load<AudioClip>("DashSound");
        dashAttackSound = Resources.Load<AudioClip>("DashAttackSound");

        audioSrc = GetComponent<AudioSource>();
	}
	
	void Update () {
		
	}

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Fire1":
                audioSrc.PlayOneShot(fireSound);
                break;
            case "Dash":
                audioSrc.PlayOneShot(dashSound);
                break;
            case "Attack":
                audioSrc.PlayOneShot(dashAttackSound);
                break;
        }
    }
}
