
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI; // 追加


public class GoalManager : MonoBehaviour
{
    //ユニティちゃんを格納するための変数
    public GameObject player;
    //テキストを格納するための変数
    public GameObject text;

    public GameObject enemy;
 
    //Goalしたかどうか判定する
    public bool isGoal = false;

    //次のゲームの名前
    public string nextGame;

    void Update()
    {
        //Goalした後で画面をクリックされたとき
        if(isGoal && Input.GetMouseButton(0))
        {
            Restart();
        }
    }
 
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == player.name)
        {
            isGoal = true;

            text.GetComponent<Text>().text = "Goal!!!\nClick to NextStage";
            text.SetActive(true);

            enemy.GetComponent<NavMeshAgent>().speed = 0;

            isGoal = true;
        }
    }
 
    private void Restart()
    {
        SceneManager.LoadScene(nextGame);
    }
}