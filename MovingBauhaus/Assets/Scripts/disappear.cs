using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disappear : MonoBehaviour {

    private bool playerOnPlatform = false;
    private bool hasBeenZero = false;
    private float alphaLvl = 1;

    public float alphaReduction;

    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.CompareTag("Player"))
            {
                playerOnPlatform = true;
            }
    }


    private void Update()
    {
        var alphaRed = alphaReduction * Time.deltaTime;

        if (playerOnPlatform == true)
        {
            if (alphaLvl > 0)
            {
                alphaLvl -= alphaRed;
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaLvl);
            }
            else if (alphaLvl <= 0)
            {
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<PlatformEffector2D>().enabled = false;
                playerOnPlatform = false;
            }
        }
        else
        {
            if (alphaLvl <= 0)
            {
                alphaLvl += alphaRed;
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaLvl);
                hasBeenZero = true;
            }
            else if(alphaLvl < 1 && !hasBeenZero)
            {
                alphaLvl -= alphaRed;
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaLvl);
            }
            else if (alphaLvl < 1 && hasBeenZero)
            {
                alphaLvl += alphaRed;
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaLvl);
            }
            else if (alphaLvl >= 1)
            {
                GetComponent<BoxCollider2D>().enabled = true;
                GetComponent<PlatformEffector2D>().enabled = true;
                hasBeenZero = false;
            }
        }
    }
}
