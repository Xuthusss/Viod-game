using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private AudioSource src;
    [SerializeField]
    PlayerMovement movementScript;

    [SerializeField] private AudioClip deathSoundEffect;
    // Start is called before the first frame update
    private void Start()
    {
        src = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Traps"))
        {
            Die();
        }
    }

    private void Die()
    {
        movementScript.enabled = false; // doesn't let player change velocity
        rb.bodyType = RigidbodyType2D.Static; // can't move after die by changing rigibody to static
        anim.SetTrigger("death");// trigger the death parameters in Animator
        src.clip = deathSoundEffect;
        src.Play();
    }

    private void RestartLevel()//reset the scene by LoadScene Method and animation Event on Animation window
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
