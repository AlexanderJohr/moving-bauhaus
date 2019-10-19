using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDestroyer : MonoBehaviour {

    public Text text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        text.gameObject.SetActive(false);
    }
}
