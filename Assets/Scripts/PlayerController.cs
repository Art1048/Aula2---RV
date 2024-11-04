using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{

    public Text placar;
    public Transform spawnPoint;
    public Transform cameraPlayer;
    public GameObject bulletPrefab;
    private Vector3 cameraOffset;
    private int points;
    public float rotationSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        cameraOffset = cameraPlayer.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;


        transform.Rotate(0,x,0);
        transform.Translate(0,0,z);

        UpdateCameraPosition();

        if(Input.GetKeyDown(KeyCode.Space)){
            Fire();
        }
    }

    void UpdateCameraPosition()
    {
        Vector3 desiredPosition = transform.position + transform.rotation * cameraOffset;

        cameraPlayer.position = Vector3.Lerp(cameraPlayer.position, desiredPosition, Time.deltaTime * rotationSpeed);

        cameraPlayer.LookAt(transform);
    }

    public void UpdateScore()
    {
        points++;
        placar.text = "Giorges mortos: " + points;

    }

    void Fire(){
        var bullet = (GameObject) Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6f;
        AudioSource som = GetComponent<AudioSource>();
        som.Play();
        Destroy(bullet, 3.0f);
    }
}
