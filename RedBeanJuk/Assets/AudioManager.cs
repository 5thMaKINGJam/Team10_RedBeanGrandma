using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("#BGM")] public AudioClip bgmClip;
    public float bgmVolume;
    private AudioSource bgmPlayer;
    
    [Header("#SFX")] public AudioClip[] sfxClip;
    public float sfxVolume;
    public int channels;
    private AudioSource[] sfxPlayer;
    private int channelIndex;
    
    
    private void Awake()
    {
        instance = this;
        Init();
    }

    public enum Sfx
    {
        addIngrediant, failingIngrediant, Tiger, EndingFuss, Success
        
    }
    

    void Init()
    {
        //배경을 초기화
        GameObject bgmObject = new GameObject("bgmPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayer = bgmObject.AddComponent<AudioSource>();
        bgmPlayer.playOnAwake = true;
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;
        bgmPlayer.clip = bgmClip;
        
        //효과음 초기화
        GameObject sfxObject = new GameObject("sfxPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayer = new AudioSource[channels];

        for (int index = 0; index < sfxPlayer.Length; index++)
        {
            sfxPlayer[index] = sfxObject.AddComponent<AudioSource>();
            sfxPlayer[index].playOnAwake = false;
            sfxPlayer[index].volume = sfxVolume;
        }

    }

    public void PlayBGM(bool isPlay)
    {
        if (isPlay)
        {
            bgmPlayer.Play();
        }
        else
        {
            bgmPlayer.Stop();
        }
    }
    public void PlaySfx(Sfx sfx)
    {
        for (int index = 0; index < sfxPlayer.Length; index++)
        {
            int loopIndex = (index + channelIndex) % sfxPlayer.Length;

            if (sfxPlayer[loopIndex].isPlaying)
            {
                continue;

                channelIndex = loopIndex;
                sfxPlayer[0].clip = sfxClip[(int)sfx];
                sfxPlayer[0].Play();
                break;
            }
        }
        
    }
    
    
}
