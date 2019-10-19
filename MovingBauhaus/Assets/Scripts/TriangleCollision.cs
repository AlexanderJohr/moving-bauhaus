using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleCollision : MonoBehaviour {

    public Material triangleMat;
    public Material triangleCollMat;

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().material = triangleMat;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        gameObject.GetComponent<SpriteRenderer>().material = triangleCollMat;
        Debug.Log("Collision!");
    }


}
