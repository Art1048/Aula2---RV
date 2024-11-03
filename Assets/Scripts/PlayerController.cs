using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Transform spawnPoint;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;


        transform.Rotate(0,x,0);
        transform.Translate(0,0,z);

        if(Input.GetKeyDown(KeyCode.Space)){
            Fire();
        }
    }

    void Fire(){
        var bullet = (GameObject) Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6f;
        AudioSource som = GetComponent<AudioSource>();
        som.Play();
        Destroy(bullet, 3.0f);

    }
}
