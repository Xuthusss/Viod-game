using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public int HP = 100;
    public Animator animator;
    public AudioClip otherClip;


    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if (HP <= 0)
        {
            GameBehavior.Instance.ZombieKilled();
            animator.SetTrigger("die"); AudioSource audio = GetComponent<AudioSource>();
            audio.clip = otherClip;
            audio.Play();

            GetComponent<CapsuleCollider>().enabled = false;
            Destroy(gameObject, 5.0f);
        }
    }
    
    
}
