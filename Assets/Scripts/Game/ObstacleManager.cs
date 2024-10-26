using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public float rotationSpeed;
    public Sprite[] spriteList;

    private void Start()
    {
        rotationSpeed = Random.Range(1, 40);
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = spriteList[Random.Range(0, 4)];
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerController>().OnDeath();
        }
    }

    private void FixedUpdate()
    {
        transform.GetChild(0).Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
