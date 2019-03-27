using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{

    public GameObject exposion;
    public GameObject playerExposion;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Border" || other.tag == "Asteroid")
        {
            return;
        }
        if (other.tag == "Player")
        {
            Instantiate(playerExposion, other.transform.position, other.transform.rotation);
        }
        Instantiate(exposion, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
