using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float PowerUpDuration = 10.0f;
    public AudioClip otherClip;
    
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
      
            StartCoroutine(BecomeInvincible());
        }
    }
    IEnumerator BecomeInvincible()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = otherClip;
        audio.Play();
       
   
        Debug.Log("Got Power Up!");
        gameObject.GetComponent<BoxCollider>().enabled = false;
        transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().enabled = false;

        GameBehavior.Instance.isInvincible = true;

        yield return new WaitForSeconds(PowerUpDuration);

        GameBehavior.Instance.isInvincible = false;

        
    }
}
