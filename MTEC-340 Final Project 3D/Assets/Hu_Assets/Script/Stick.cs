using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Stick : MonoBehaviour
{
    public int damageAmount = 100;
    
    // Reference to the Input Action
    private InputAction attackAction;
    public AudioClip otherClip;

    private void OnEnable()
    {
        // Enable the Input Action when the script is enabled
        attackAction.Enable();
    }

    private void OnDisable()
    {
        // Disable the Input Action when the script is disabled
        attackAction.Disable();
    }

    private void Awake()
    {
        // Get a reference to the Input Action
        attackAction = new InputAction("Attack", binding: "<Mouse>/leftButton"); // Replace "Gamepad" and "buttonSouth" with the appropriate control scheme and binding for your game
        attackAction.performed += _ => Attack();
    }

    private void Attack()
    {
        StartCoroutine(AttackAnimation());

    }
    IEnumerator AttackAnimation()
    {
        yield return new WaitForSeconds(.3f);
        
        // Perform the attack action here, e.g., swing the stick

        // Check if the stick is touching any collider (including the Zombie)
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2f);

        foreach (Collider collider in colliders)
        {
            // Check if the collider belongs to a Zombie
            if (collider.tag == "Zombie")
            {
                collider.GetComponent<Zombie>().TakeDamage(damageAmount);
                AudioSource audio = GetComponent<AudioSource>();
                audio.clip = otherClip;
                audio.Play();
            }
        }
    }
}
