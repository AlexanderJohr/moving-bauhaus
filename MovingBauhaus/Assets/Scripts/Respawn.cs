using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    public Player player;
    public GameObject deathParticle;
    public Transform respawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 deathPos = player.transform.position;
            deathParticle.transform.position = deathPos;
            Instantiate(deathParticle);
            player.transform.position = respawn.transform.position;
        }
    }
}
