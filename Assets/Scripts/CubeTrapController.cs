using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeTrapController : MonoBehaviour
{
   private void OnCollisionEnter(Collision other){

    if(other.gameObject.CompareTag("Player")){
        AudioSource somMorte = GetComponent<AudioSource>();
        Destroy(other.gameObject);
        somMorte.Play();
    }

   }
}
