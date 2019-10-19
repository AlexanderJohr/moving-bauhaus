using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;

    public AudioMixer audiomix;
    
    // Use this for initialization
	void Awake ()
    {

        if (instance == null)
            instance = this;
        else{
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        float bgmVol = PlayerPrefs.GetFloat("BGMVol", 0);
        float fxVol = PlayerPrefs.GetFloat("FXVol", 0);
        audiomix.SetFloat("BGMVol", bgmVol);
        audiomix.SetFloat("FXVol", fxVol);

    }

    public void SetBGM(float volume)
    {
        audiomix.SetFloat("BGMVol", volume);
        PlayerPrefs.SetFloat("FXVol", volume);
        PlayerPrefs.Save();
    }

    public void SetEffects(float volume)
    {
        audiomix.SetFloat("FXVol", volume);
        PlayerPrefs.SetFloat("FXVol", volume);
        PlayerPrefs.Save();
    }
}
