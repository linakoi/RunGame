using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityChan;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{

    public Text timeText;

    public float limit = 30.0f;

    public GameObject text;

    public GameObject player;

    private RestartManager restart;


    void Start()
    {
        restart = new RestartManager(player, text);
        timeText.text = "Žc‚èŽžŠÔ:" + limit + "•b";
    }

    void Update()
    {
        if (restart.IsGameOver() && Input.GetMouseButton(0))
        {
            restart.Restart();
        }

        if (limit < 0)
        {
            restart.PrintGameOver("Time Over...");

            return;
        }

        limit -= Time.deltaTime;
        timeText.text = "Žc‚èŽžŠÔ:" + limit.ToString("f1") + "•b";
    }

    private void Restart()
    {
        Scene loadScene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(loadScene.name);
    }
}