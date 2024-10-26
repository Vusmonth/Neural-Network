using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x < -1)
        {
            Destroy(gameObject);
        }

        if (transform.position.x < 2.5f)
        {
            transform.tag = "Untagged";
        }
    }
}
