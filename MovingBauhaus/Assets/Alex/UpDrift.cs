using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDrift : MonoBehaviour
{

    private Player _player;

    void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    void Start()
    {
    }

    void Update()
    {
        var distToPlayer = Vector3.Distance(_player.transform.position, this.transform.position);

        Vector2 vectorToPlayer = _player.transform.position - this.transform.position;

        var dotResult = Vector3.Dot(Vector3.up, vectorToPlayer.normalized);

        bool playerIsInUpDrift = dotResult > 0.9;
        bool playerIsNotToFarAway = distToPlayer < 16;

        if (playerIsInUpDrift && playerIsNotToFarAway) {
            _player.Rb.AddForce(Vector3.up * 9.91f);
        }
    }
}
