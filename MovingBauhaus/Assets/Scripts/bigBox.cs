using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigBox : MonoBehaviour {

    public rotateBig Target;
    public cameraShake cameraShake;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Target.playerOnPlatform = true;
            cameraShake.Shake(0.2f, 1f);
        }
    }
}
