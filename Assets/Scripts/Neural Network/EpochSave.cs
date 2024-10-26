using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Epoch
{
    public string id;
    public float playerScore;
    public float[] weights;
}

public class EpochSave : MonoBehaviour
{
    public List<Epoch> EpochDataList = new List<Epoch>();
    public int totalPlayers;
    public bool gameEnd;
    public GameObject retryModal;
    public TextMeshProUGUI finalScore;
    public TextMeshProUGUI scoreInGame;
    private float score;
    public AudioSource audioSrc;

    void Start()
    {
        totalPlayers = GameObject.FindGameObjectsWithTag("Player").Length;
        DontDestroyOnLoad(audioSrc.gameObject);
    }

    private void FixedUpdate()
    {
        gameEnd = GameObject.FindGameObjectsWithTag("Player").Length == 0;
        retryModal.SetActive(gameEnd);
        try
        {
            score = GameObject.FindGameObjectsWithTag("Player").Last().GetComponent<PlayerController>().score * 10;
        }
        catch (Exception) { }

        finalScore.text = ((Int32)score).ToString();
        scoreInGame.text = ((Int32)score).ToString();

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);

    }

    // Update is called once per frame
    public void SaveData(Epoch data)
    {
        EpochDataList.Add(data);
        if (EpochDataList.Count == totalPlayers)
        {
            Epoch lastStanding = EpochDataList.Last();
            WriteJson(lastStanding);
            //salvar no player prefs
        }
    }

    void WriteJson(Epoch data)
    {
        //string json = JsonConvert.SerializeObject(myObject, Formatting.Indented);
        string filePath = Application.dataPath + "/Epoch.json";
        string json = JsonUtility.ToJson(data);

        File.AppendAllText(filePath, (json + ','));
    }
}
