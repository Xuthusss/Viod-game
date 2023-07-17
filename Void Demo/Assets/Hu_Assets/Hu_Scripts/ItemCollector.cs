using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemCollector : MonoBehaviour
{
    private int _bananas = 0;
    private int Bananas
    {
        get { return _bananas; }

        set
        {
            _bananas = value;
            Debug.Log("Bananas Collected: " + _bananas);
        }
    }


    AudioSource src;

    [SerializeField] private Text bananasText;

    [SerializeField] private AudioClip collectionSoundEffect;

    private void Start()
    {
        src = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)// collider with player 
    {
        if (collision.gameObject.CompareTag("Bananas"))
        {
            Destroy(collision.gameObject);//remove the items from the game
            Bananas++;// increase text numbers
            bananasText.text = "Bananas:" + Bananas;

            src.clip = collectionSoundEffect;
            src.Play();
        }
    }
}
