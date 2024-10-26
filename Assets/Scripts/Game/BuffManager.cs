using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerController>().GetPoint();
            Destroy(gameObject);
        }
    }
}
