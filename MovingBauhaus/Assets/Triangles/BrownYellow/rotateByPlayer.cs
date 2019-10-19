using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateByPlayer : MonoBehaviour {

    public float waitTime;
    public float rotSpeed;
    public float zRotation;
    public float colorSpeed;
    public Player player;
    public Transform playerLock;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;

    [HideInInspector]
    public bool playerOnPlatform = false;

    private float remainingTime;
    private float colorUp;
    private float volScale;
    private bool rotateTriangle = false;
    private Vector3 offset;
    private Vector3 lastRot;
    private Material shaderMat;
    private AudioSource audioS;

    Quaternion startRot;
    Quaternion desiredRot;

    private void Start()
    {
        startRot = transform.rotation;
        remainingTime = waitTime;
    }

    private void OnEnable()
    {
        audioS = GetComponent<AudioSource>();
        shaderMat = GetComponent<Renderer>().material;
        colorUp = 0.42f;
        shaderMat.SetFloat("_Color_Change_Down_float", colorUp);
    }


    void Update()
    {

        desiredRot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, zRotation);

        if (playerOnPlatform == true && transform.rotation != desiredRot)
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
                //else { audioS.UnPause(); }
                colorUp -= colorSpeed;
                shaderMat.SetFloat("_Color_Change_Down_float", colorUp);
            }
        }

        else
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
                //else { audioS.UnPause(); }
                colorUp += colorSpeed;
                shaderMat.SetFloat("_Color_Change_Down_float", colorUp);
            }
        }

        if (rotateTriangle == true)
        {
           // volScale = 0.5f;
           // audioS.PlayOneShot(clip2, volScale);
           // if (!GetComponent<Renderer>().isVisible) { audioS.Pause(); }
           // else { audioS.UnPause(); }
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);

        }
        else if (rotateTriangle == false && playerOnPlatform == false)
        {
            remainingTime -= Time.deltaTime;
            if (remainingTime <= 0)
            {
              //  volScale = 0.5f;
              //  audioS.PlayOneShot(clip3, volScale);
              //  if (!GetComponent<Renderer>().isVisible) { audioS.Pause(); }
              //  else { audioS.UnPause(); }
                transform.rotation = Quaternion.Lerp(transform.rotation, startRot, rotSpeed * Time.deltaTime);
            }
        }

        lastRot = transform.rotation.eulerAngles;
    }

    private void LateUpdate()
    {
        if (rotateTriangle == true)
        {
            player.transform.position = playerLock.transform.position;
            player.ignore = true;
        }
        else
        {
            player.ignore = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerOnPlatform = true;
        remainingTime = waitTime;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerOnPlatform = false;
    }
}
