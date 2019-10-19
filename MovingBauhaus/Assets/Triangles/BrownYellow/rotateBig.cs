using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateBig : MonoBehaviour {


    public float rotSpeed;
    public float zRotation;
    public Player player;
    public float colorSpeed;
    public AudioClip clip1;

    [HideInInspector]
    public bool playerOnPlatform = false;

    private bool rotateTriangle = false;
    private Material shaderMat;
    private float colorUp;
    private float volScale;
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

    void Update()
    {

        desiredRot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, zRotation);

        if (playerOnPlatform == true)
        {
            if (colorUp <= 0f)
            {
                rotateTriangle = true;
            }
            else
            {
                volScale = 0.3f;
                audioS.PlayOneShot(clip1, volScale);
                colorUp -= colorSpeed;
                shaderMat.SetFloat("_Color_Change_Down_float", colorUp);
            }
        }
        else if (transform.rotation == desiredRot && playerOnPlatform == false)
        {
            if (colorUp >= 0.42f)
            {
                rotateTriangle = false;
            }
            else
            {
                volScale = 0.3f;
                audioS.PlayOneShot(clip1, volScale);
                colorUp += colorSpeed;
                shaderMat.SetFloat("_Color_Change_Down_float", colorUp);
            }
        }
        else if (playerOnPlatform == false)
        {
        }

        if (rotateTriangle == true)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
        }
        else if (rotateTriangle == false)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, startRot, rotSpeed * Time.deltaTime); 
        }


    }


}
