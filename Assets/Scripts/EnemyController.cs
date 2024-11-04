using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed ; 

    private bool isPlayerInTrigger = false; 
    private GameObject player;

void Update()
    {
         if (isPlayerInTrigger)
        {
            FollowPlayer(player);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            isPlayerInTrigger = true;
            player = other.gameObject;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            isPlayerInTrigger = false; 
        }
    }

    private void OnCollisionEnter(Collision other){

    if(other.gameObject.CompareTag("Player")){
        AudioSource somMorte = GetComponent<AudioSource>();
        Destroy(other.gameObject);
        somMorte.Play();
    }

   }

    
    private void FollowPlayer(GameObject player)
    {
    
        Vector3 direction = (player.transform.position - transform.position).normalized;

        transform.position += direction * speed * Time.deltaTime;
        
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);
    }
}
