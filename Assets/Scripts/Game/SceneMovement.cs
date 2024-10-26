using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMovement : MonoBehaviour
{
    [Range(0f, 2f)]
    public float velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector3(velocity, 0, 0));
    }
}
