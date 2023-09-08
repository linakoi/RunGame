using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    public GameObject player;

    public GameObject text;

    private RestartManager restart;

    private void Start()
    {
        restart = new RestartManager(player, text);
    }

    private void Update()
    {
        if(player.transform.position.y < -10)
        {
            restart.PrintGameOver("Fall down...");
        }

        if(restart.IsGameOver() && Input.GetMouseButton(0)) {
            restart.Restart();
        }
    }
}
