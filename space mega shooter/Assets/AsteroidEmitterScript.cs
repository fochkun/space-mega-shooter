using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidEmitterScript : MonoBehaviour
{

    public float minDelay;
    public float maxDelay;

    public GameObject asteroid;

    private float nextSpawn;
    private float asteroidCount = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            float maxAsteroids = Random.Range(1, asteroidCount);

            for (int idx = 0; idx < maxAsteroids; idx++)
            {

                nextSpawn = Time.time + Random.Range(minDelay, maxDelay);

                float randomXPosition = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
                float randomZPosition = transform.position.z + Random.Range(0, 5);
                Vector3 startPosition = new Vector3(
                    randomXPosition,
                    transform.position.y,
                    randomZPosition
                    );
                Instantiate(asteroid, startPosition, Quaternion.identity);
            }

            asteroidCount += 0.3f;
        }
    }
}
