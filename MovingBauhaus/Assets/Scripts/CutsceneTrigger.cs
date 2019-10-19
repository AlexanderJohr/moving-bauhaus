using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour {

    public GameObject activeCamera;
    public Player activePlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        activeCamera.gameObject.GetComponent<Animator>().enabled = true;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

}
