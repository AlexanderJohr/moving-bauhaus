using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class goal : MonoBehaviour {

    private bool playerLockB;

    public Transform goalSprite;
    public GameObject finalButton;
    public Text displayText;
    public Transform playerLock;
    public Player player;

    private void Start()
    {
        playerLockB = false;
    }

    void Update () {
        goalSprite.Rotate(0, 0, 1f);
    }

    private void LateUpdate()
    {
        if (playerLockB)
        {
            player.transform.position = Vector3.Lerp(player.transform.position, playerLock.transform.position, 1f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.ignore = true;
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
            playerLockB = true;
            displayText.alignment = TextAnchor.MiddleCenter;
            displayText.text = "You did it!";
            finalButton.SetActive(true);
        }
    }

    public void OnPush()
    {
        displayText.text = "";
        finalButton.SetActive(false);
        SceneManager.LoadScene("LevelSelection");
    }
}
