using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollevtableItems : MonoBehaviour
{
    private int ColleveableItems = 0;

    [SerializeField] private Text colleveableItemsText;

    [SerializeField] private AudioSource collectionSoundEffect;

    [SerializeField] private float multiplier = 0;

    private void OnTriggerEnter2D(Collider2D collision)// collider with player 
    {
        if (collision.gameObject.CompareTag("ColleveableItems"))
        {
            Destroy(collision.gameObject);//remove the items from the game
            ColleveableItems++;// increase text numbers
            colleveableItemsText.text = "Psyche: " + ColleveableItems;
            collectionSoundEffect.Play();
            Powerup();

        }
    }

    private void Powerup()// power up method
    {
        transform.localScale *= multiplier;
        
    }
}
