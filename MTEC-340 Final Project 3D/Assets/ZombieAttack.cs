using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    CapsuleCollider col;


    Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        col.enabled = false;
    }

    private void Awake()
    {
        col = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance < 2.5f)
        {
            col.enabled = true;
        }
        else
            col.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameBehavior.Instance.PlayerHurt();
        }
    }

    
}
