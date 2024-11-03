using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            float RamdomX = UnityEngine.Random.Range(-15, 15);
            float RamdomZ = UnityEngine.Random.Range(-15, 15);

            GameObject zombie = Instantiate(Resources.Load("Georgi", typeof(GameObject))) as GameObject;

            zombie.transform.position = new Vector3(RamdomX, 1, RamdomZ);
            zombie.transform.rotation = Quaternion.Euler(0, UnityEngine.Random.Range(0, 360), 0);

            Destroy(gameObject);
        }

    }
}
