using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disappearColored : MonoBehaviour {

    private bool playerOnPlatform = false;
    private float dissolveFloat;
    private Material dissolveMat;
    private AudioSource audioS;
    private float audioFade = 0.2f;
    private float volScale = 0.5f;

    public SourceManager audioArr;
    public AudioClip clip1;
    public AudioClip clip2;
    public float reductionFloat;

    void OnEnable()
    {
        audioS = GetComponent<AudioSource>();
        dissolveMat = GetComponent<Renderer>().material;
        dissolveFloat = 0f;
        dissolveMat.SetFloat("Vector1_6B818D03", dissolveFloat);
    }

    private void Update()
    {
        //if (!GetComponent<Renderer>().isVisible){ audioS.Pause(); }
        //else { audioS.UnPause(); } 

        if (playerOnPlatform)
        {

            if (dissolveFloat >= 100)
            {

                dissolveFloat = 100f;
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<PlatformEffector2D>().enabled = false;
                playerOnPlatform = false;
            }
            else
            {
                audioS.clip = clip1;
                audioArr.AddSource(audioS);
                dissolveFloat = dissolveFloat + reductionFloat;
                dissolveMat.SetFloat("Vector1_6B818D03", dissolveFloat);
            }
        }
        else
        {
            if (dissolveFloat <= 0)
            {
                audioS.clip = null;
                dissolveFloat = 0f;
                GetComponent<BoxCollider2D>().enabled = true;
                GetComponent<PlatformEffector2D>().enabled = true;
            }

            else if (dissolveFloat <= 70)
            {
                audioS.clip = clip2;
                //if (!GetComponent<Renderer>().isVisible) { audioS.Pause(); }
                //else { audioS.UnPause(); }
                dissolveFloat = dissolveFloat - reductionFloat * 2;
                dissolveMat.SetFloat("Vector1_6B818D03", dissolveFloat);
                GetComponent<BoxCollider2D>().enabled = true;
                GetComponent<PlatformEffector2D>().enabled = true;
            }
            else
            {
                audioS.clip = clip2;
                //if (!GetComponent<Renderer>().isVisible) { audioS.Pause(); }
                //else { audioS.UnPause(); }
                dissolveFloat = dissolveFloat - reductionFloat * 2;
                dissolveMat.SetFloat("Vector1_6B818D03", dissolveFloat);

            }

        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = true;
        }
    }
}
