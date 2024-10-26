using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBuffs : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    public GameObject[] obstacles;
    public float velocity;
    [Range(0f, 25f)]
    public float distanceToSpawn;
    GameObject newObstacle;
    Vector3 spawnPosition;

    void Start()
    {
        velocity = -10;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetMaxObstaclesLimit();

        if (velocity > -150)
        {
            velocity = velocity - 0.015f;
        }
        obstacles = GameObject.FindGameObjectsWithTag("Point");

        if (!HasNearObstacle())
        {
            spawnPosition = new Vector2(transform.position.x, Random.Range(-0.5f, 9));
            newObstacle = Instantiate(prefab, spawnPosition, Quaternion.identity);
            newObstacle.GetComponent<ConstantForce2D>().relativeForce = new Vector2(velocity, 0);
        }

    }

    void SetMaxObstaclesLimit()
    {
        if (velocity <= -10) distanceToSpawn = 7;
        if (velocity < -30) distanceToSpawn = 6.5f;
        if (velocity < -70) distanceToSpawn = 6f;
        if (velocity < -110) distanceToSpawn = 5.5f;
    }

    bool HasNearObstacle()
    {
        bool result = false;
        foreach (var obstacle in obstacles)
        {
            float distance = (obstacle.transform.position.x - 25) * -1;
            if (distance > distanceToSpawn)
            {
                continue;
            }
            else
            {
                result = true;
            }
        }
        return result;
    }
}
