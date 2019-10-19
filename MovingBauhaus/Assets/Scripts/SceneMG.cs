using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMG : MonoBehaviour {

    public static bool Audiosetup = false;

    public void MovePlayScecne()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void MoveOptionScene()
    {
        SceneManager.LoadScene("Option");
    }

    public void MoveLevelSelectionScene()
    {
        
        SceneManager.LoadScene("LevelSelection");
        if (!MenuAudioDon.Instance.gameObject.GetComponent<AudioSource>().isPlaying) { MenuAudioDon.Instance.gameObject.GetComponent<AudioSource>().Play(); }
    }

    public void MoveTestLevel()
    {
        SceneManager.LoadScene("TestLevel");
        Time.timeScale = 1;
    }

    public void MovetitleScene()
    {
        
        SceneManager.LoadScene("TitleScreen");
        if (!MenuAudioDon.Instance.gameObject.GetComponent<AudioSource>().isPlaying) { MenuAudioDon.Instance.gameObject.GetComponent<AudioSource>().Play(); }
    }

    public void MoveAudioScene()
    {
        SceneManager.LoadScene("Audio");
        Audiosetup = true;
    }

    public void MoveGeneralScene()
    {
        SceneManager.LoadScene("General");
    }

    public void MoveCreditScene()
    {
        SceneManager.LoadScene("Credits");
    }

    public void MoveSchlemmerScene()
    {
        SceneManager.LoadScene("GoetheInstitute");
    }

}

