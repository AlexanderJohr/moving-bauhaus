using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour {

    public TextsToDisplay parent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.gameObject.GetComponent<ParticleSystem>().Stop();
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        parent.DisplayText();
    }
}
