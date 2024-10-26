using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float score;
    EpochSave epochSaveManager;

    void Start()
    {
        epochSaveManager = GameObject.FindObjectOfType<EpochSave>();
    }

    public void Jump()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = (transform.up * 8.5f);
    }

    public void OnDeath()
    {
        Epoch epochData = new Epoch();
        epochData.id = transform.name;
        epochData.playerScore = score;
        epochData.weights = gameObject.GetComponent<SigmoidPerceptron>().weightsInputHidden;

        epochSaveManager.SaveData(epochData);
        gameObject.SetActive(false);
    }

    public void GetPoint()
    {
        score += 3;
    }

    void FixedUpdate()
    {
        score = score + 0.01f;

        if (Input.GetKey(KeyCode.Space))
        {
            this.Jump();
        }
    }
}
