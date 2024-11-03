using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{

    public GameObject cubeTrap;
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            AudioSource sound = GetComponent<AudioSource>();
            sound.Play();

            for(int i = 0; i < 7; i++){
                float randomX = UnityEngine.Random.Range(transform.position.x-15,transform.position.x+15);
                float randomZ = UnityEngine.Random.Range(transform.position.z-15,transform.position.z+15);

                var cube = Instantiate(cubeTrap, new Vector3(randomX, 15, randomZ), Quaternion.identity);

                Destroy(cube, 5.0f);
            }
        }
    }
}
