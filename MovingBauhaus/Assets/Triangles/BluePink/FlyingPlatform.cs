using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPlatform : MonoBehaviour {

    public Transform player;

    public float flyingSpeed;
    public float yPosition;
    public float waitTime;
    public float colorSpeed;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;

    private bool playerOnPlatform = false;
    private bool flying = false;
    private float colorUp;
    private float volScale;
    private Material shaderMat;
    private AudioSource audioS;

    Vector3 startPos;
    Vector3 desiredPos;

    // Use this for initialization
    void Start () {
        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z); ;
    }

    private void OnEnable()
    {
        audioS = GetComponent<AudioSource>();
        shaderMat = GetComponent<Renderer>().material;
        colorUp = 0f;
        shaderMat.SetFloat("Vector1_8E8D540C", colorUp);
    }

    // Update is called once per frame
    void Update () {
        
        desiredPos =  new Vector3(transform.position.x, yPosition, transform.position.z);

        if (playerOnPlatform == true)
        {
            if (colorUp >= 0.41f)
            {
                flying = true;
            }
            else
            {
                volScale = 0.3f;
                audioS.PlayOneShot(clip1, volScale);
               // if (!GetComponent<Renderer>().isVisible) { audioS.Pause(); }
               // else { audioS.UnPause(); }
                colorUp += colorSpeed;
                shaderMat.SetFloat("Vector1_8E8D540C", colorUp);
            }
        }
        else if (transform.position.y >= yPosition -0.2f && playerOnPlatform == false)
        {
            if (colorUp <= 0f)
            {
                audioS.Stop();
                flying = false;
            }
            else
            {
                volScale = 0.3f;
                audioS.PlayOneShot(clip1, volScale);
               // if (!GetComponent<Renderer>().isVisible) { audioS.Pause(); }
                //else { audioS.UnPause(); }
                colorUp -= colorSpeed;
                shaderMat.SetFloat("Vector1_8E8D540C", colorUp);
            }
        }

        if (flying == true)
        {
            //volScale = 0.5f;
            //audioS.PlayOneShot(clip2, volScale);
            //if (!GetComponent<Renderer>().isVisible) { audioS.Pause(); }
            //else { audioS.UnPause(); }
            transform.position = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * flyingSpeed);
        }
        else if (flying == false)
        {
            //volScale = 0.5f;
            //audioS.PlayOneShot(clip3, volScale);
            //if (!GetComponent<Renderer>().isVisible) { audioS.Pause(); }
            //else { audioS.UnPause(); }
            transform.position = Vector3.Lerp(transform.position, startPos, Time.deltaTime * flyingSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = true;
            player.transform.SetParent(transform);
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {    
        playerOnPlatform = false;
        player.transform.SetParent(null);
        player.GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}
