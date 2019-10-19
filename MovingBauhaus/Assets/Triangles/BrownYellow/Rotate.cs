using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public float rotSpeed;
    public float zRotation;
    public float colorSpeed;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;

    [HideInInspector]
    public bool playerOnPlatform = false;

    private float colorUp;
    private bool rotateTriangle = false;
    private float remainingWaitTime;
    private float volScale;
    private Material shaderMat;
    private AudioSource audioS;

    Quaternion startRot;
    Quaternion desiredRot;

    private void Start()
    {
        startRot = transform.rotation;
    }

    private void OnEnable()
    {
        audioS = GetComponent<AudioSource>();
        shaderMat = GetComponent<Renderer>().material;
        colorUp = 0.42f;
        shaderMat.SetFloat("_Color_Change_Down_float", colorUp);
    }

    void Update () {
        
        desiredRot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, zRotation);

        if (playerOnPlatform == true)
        {
            if (colorUp <= 0f)
            {
                audioS.Stop();
                rotateTriangle = true;
            }
            else
            {
                volScale = 0.3f;
                audioS.PlayOneShot(clip1, volScale);
                //if (!GetComponent<Renderer>().isVisible) { audioS.Pause(); }
               // else { audioS.UnPause(); }
                colorUp -= colorSpeed;
                shaderMat.SetFloat("_Color_Change_Down_float", colorUp);
            }
        }
        else if (transform.rotation == desiredRot && playerOnPlatform == false)
        {
            if (colorUp >= 0.42f)
            {
                audioS.Stop();
                rotateTriangle = false;
            }
            else
            {
                volScale = 0.3f;
                audioS.PlayOneShot(clip1, volScale);
                //if (!GetComponent<Renderer>().isVisible) { audioS.Pause(); }
               // else { audioS.UnPause(); }
                colorUp += colorSpeed;
                shaderMat.SetFloat("_Color_Change_Down_float", colorUp);
            }
        }

        if (rotateTriangle == true)
        {
            //volScale = 0.5f;
           // audioS.PlayOneShot(clip2, volScale);
           // if (!GetComponent<Renderer>().isVisible) { audioS.Pause(); }
            //else { audioS.UnPause(); }
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
        }
        else if (rotateTriangle == false)
        {
          //  volScale = 0.5f;
           // audioS.PlayOneShot(clip3, volScale);
           // if (!GetComponent<Renderer>().isVisible) { audioS.Pause(); }
          //  else { audioS.UnPause(); }
            transform.rotation = Quaternion.Lerp(transform.rotation, startRot, rotSpeed * Time.deltaTime); ;
        }


    }

   /* private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
         playerOnPlatform = false;
    }
    */
}
