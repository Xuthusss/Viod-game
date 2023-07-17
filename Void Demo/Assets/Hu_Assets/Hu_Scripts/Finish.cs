using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;

    private bool levelCompleted = false;

    // Start is called before the first frame update
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)//check if player trigger collision and level is completed，paly SFX and finish level 1 in 3s
        {
            finishSound.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 3f);
        }
    }

    private void CompleteLevel()// LoadScene by buildindex + 1 which is level 2
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
