using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceManager : MonoBehaviour {

    [HideInInspector]
    public AudioSource[] sourceArray;

    private void Start()
    {
        sourceArray = new AudioSource[3];
        sourceArray[0] = null;
        sourceArray[1] = null;
        sourceArray[2] = null;
    }

    private void Update()
    {
        for(int s = 0; s < 3; s++)
        {
            if (sourceArray[s] == null || sourceArray[s].clip == null)
            {
                sourceArray[s] = null;
            }
        }

        if (sourceArray[0] == null || sourceArray[0].clip == null) { }
        else
        {
            if (!sourceArray[0].isPlaying)
            {
                sourceArray[0].volume = 1f;
                sourceArray[0].Play();
            }
        }
        if (sourceArray[1] == null || sourceArray[1].clip == null) { }
        else
        {
            if (!sourceArray[1].isPlaying)
            {
                sourceArray[1].volume = 0.7f;
                sourceArray[1].Play();
            }
        }
        if (sourceArray[2] == null || sourceArray[2].clip == null) { }
        else
        {
            if (!sourceArray[2].isPlaying)
            {
                sourceArray[2].volume = 0.4f;
                sourceArray[2].Play();
            }
        }
    }

    public void AddSource(AudioSource source)
    {
        if (sourceArray[1] == null) { }
        else {
            sourceArray[2] = sourceArray[1];
        }
        if (sourceArray[0] == null) { }
        else{
            sourceArray[1] = sourceArray[0];
        }
        sourceArray[0] = source;
    }
}
