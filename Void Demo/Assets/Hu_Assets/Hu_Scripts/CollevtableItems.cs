using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollevtableItems : MonoBehaviour
{
    private int ColleveableItems = 0;

    AudioSource src;

    [SerializeField] private Text colleveableItemsText;

    [SerializeField] private AudioClip collectionSoundEffect;

    private void Start()
    {
        src = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)// collider with player 
    {
        if (collision.gameObject.CompareTag("ColleveableItems"))
        {
            Destroy(collision.gameObject);//remove the items from the game
            ColleveableItems++;// increase text numbers
            colleveableItemsText.text = "Psyche: " + ColleveableItems;
            src.clip = collectionSoundEffect;
            src.Play();

        }
    }

}
