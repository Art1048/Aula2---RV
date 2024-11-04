using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrapController : MonoBehaviour
{
    public GameObject JumpCube;
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){

            AudioSource sound = GetComponent<AudioSource>();

            sound.Play();

            Vector3 TrapPosition = new Vector3(transform.position.x, -5, transform.position.z);

            var cube = Instantiate(JumpCube, TrapPosition, Quaternion.identity);

            Destroy(cube, 6.0f);
        }
    }
}
