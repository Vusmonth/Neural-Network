using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceController : MonoBehaviour
{
    public float score;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            gameObject.GetComponent<PlayerController>().Jump();
        }
    }
}
