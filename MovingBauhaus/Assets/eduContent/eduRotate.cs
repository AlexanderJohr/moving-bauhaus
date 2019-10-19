using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eduRotate : MonoBehaviour {

    public float rotationSpeed;
    public TextsToDisplay parent;

    private void Start()
    {
        //this.gameObject.GetComponent<ParticleSystem>().Stop();
    }

    void Update () {

        transform.Rotate(0,0, rotationSpeed) ;

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.gameObject.GetComponent<ParticleSystem>().Play();
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        parent.DisplayText();
    }
}
