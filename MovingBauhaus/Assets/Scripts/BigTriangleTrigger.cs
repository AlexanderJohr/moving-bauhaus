using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigTriangleTrigger : MonoBehaviour {

    public rotateBig bigTriangle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bigTriangle.playerOnPlatform = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        bigTriangle.playerOnPlatform = false;
    }
}
