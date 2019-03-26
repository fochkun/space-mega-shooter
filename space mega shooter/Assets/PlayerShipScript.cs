using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerShipScript : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject lazerShot;
    public GameObject lazerGun;
    public float shotDelay;
    private float nextShotTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool canShot = Time.time > nextShotTime;
        if (canShot && Input.GetButton("Fire1"))
        {
            nextShotTime = Time.time + shotDelay;
            Instantiate(lazerShot, lazerGun.transform.position, Quaternion.identity);
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Rigidbody ship = GetComponent<Rigidbody>();
        float posX = horizontal * speed;
        float posZ = vertical * speed;
        ship.velocity= new Vector3(posX, 0, posZ);
        ship.rotation = Quaternion.Euler(ship.velocity.z * tilt, 0, -ship.velocity.x * tilt);

        float xPosition = Mathf.Clamp(ship.position.x, boundary.xMin, boundary.xMax);
        float zPosition = Mathf.Clamp(ship.position.z, boundary.zMin, boundary.zMax);
        ship.position = new Vector3(xPosition, 0, zPosition);
    }
}
