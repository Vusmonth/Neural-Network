using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimoidParams
{
    public float obstacle_y; //posição em Y do obstaculo
    public float obstacle_h; //Altura do obstaculo
    public float obstacle_d; //Distancia entre o Player e o Obstaculo
    public float player_y; //Posição em Y do player
    public float map_velocity; //Velocidade de movimentação do mapa
    public float top_limit; //Velocidade de movimentação do mapa
    public float bot_limit; //Velocidade de movimentação do mapa

}

public class SigmoidPerceptron : MonoBehaviour
{
    SpawnObjects obstaclesData;
    PlayerController player;
    //public float[] weightsInputHidden = { 0.2f, -0.3f, 0.4f, -0.5f, 0.6f };
    public float[] weightsInputHidden;
    public float result;

    // Start is called before the first frame update
    void Start()
    {
        if (weightsInputHidden[0] == 0 && weightsInputHidden[1] == 0)
        {

            weightsInputHidden[0] = Random.Range(-99.9f, 99.9f);
            weightsInputHidden[1] = Random.Range(-99.9f, 99.9f);
            weightsInputHidden[2] = Random.Range(-99.9f, 99.9f);
            weightsInputHidden[3] = Random.Range(-99.9f, 99.9f);
            weightsInputHidden[4] = Random.Range(-99.9f, 99.9f);
            weightsInputHidden[5] = Random.Range(-99.9f, 99.9f);
            weightsInputHidden[6] = Random.Range(-99.9f, 99.9f);
        }


        obstaclesData = FindObjectOfType<SpawnObjects>();
        player = gameObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SimoidParams Params = new SimoidParams();

        if (obstaclesData.obstacles[0] == null) return;
        Params.obstacle_d = obstaclesData.obstacles[0].transform.position.x + 3;
        Params.obstacle_y = obstaclesData.obstacles[0].transform.position.y;
        Params.obstacle_h = obstaclesData.obstacles[0].transform.localScale.y;
        Params.player_y = transform.position.y;
        Params.map_velocity = -obstaclesData.velocity;
        Params.top_limit = 9;
        Params.bot_limit = -0.5f;

        result = SigmoidBinaryOutput(Params);
        if (SigmoidBinaryOutput(Params) > 0.5f)
        {
            player.Jump();
        }
    }

    public int SigmoidBinaryOutput(SimoidParams data)
    {
        float hidden = 0f;
        // Calcula os inputs com os pesos
        float[] inputList = { data.obstacle_d, data.obstacle_y, data.obstacle_h, data.player_y, data.map_velocity, data.top_limit, data.bot_limit };
        for (int i = 0; i < 7; i++)
        {
            hidden += weightsInputHidden[i] * inputList[i];
        }
        // Aplicar função de ativação (sigmoid)
        hidden = 1f / (1f + Mathf.Exp(-hidden));

        if (hidden >= 0.5f)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
