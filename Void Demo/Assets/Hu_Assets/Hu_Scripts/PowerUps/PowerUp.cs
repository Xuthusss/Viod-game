using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
   

    private SpriteRenderer sprite;

    protected GameObject player;
    protected PlayerMovement playerScript;

    bool hasEntered = false;

    public virtual void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !hasEntered)
        {
          
                TriggerPowerUp();
                sprite.enabled = false;
                Destroy(gameObject, 1.0f);

                hasEntered = true; // makes sure player can't trigger twice
        }
    }

    public virtual void TriggerPowerUp()
    {
        Debug.Log("Power Up!");
        // power up logic
    }
}
