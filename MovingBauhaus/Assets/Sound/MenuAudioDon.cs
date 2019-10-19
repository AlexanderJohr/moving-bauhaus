using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioDon : MonoBehaviour {

    private static MenuAudioDon instance = null;
    public static MenuAudioDon Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
