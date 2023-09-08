
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityChan;
using UnityEngine.UI;

public class DeadWallScript : MonoBehaviour
{
    //オブジェクトの速度
    public float speed;
    //オブジェクトの横移動の最大距離
    public float max_x;

    private int init_direction;

    //unitychan
    public GameObject player;

    //テキスト
    public GameObject text;

    //ゲームオーバー
    private bool isGameOver = false;


    private void Start()
    {
        init_direction = Random.Range(0, 2);
        if(init_direction == 0)
        {
            speed *= -1.0f;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(isGameOver && Input.GetMouseButton(0))
        {
            Restart();
        }

        //フレーム毎speedの値分だけx軸方向に移動する
        this.gameObject.transform.Translate(speed, 0, 0);

        //Transformのxの値が一定値を超えたときに向きを反対にする
        if (this.gameObject.transform.position.x > max_x || this.gameObject.transform.position.x < (-max_x))
        {
            speed *= -1.0f;
            Debug.Log(speed);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        //接触したオブジェクトがユニティちゃんのとき
        if (other.gameObject.name == player.name)
        {
            //ゲームオーバーを表示する
            text.GetComponent<Text>().text = "GameOver...";
            text.SetActive(true);

            //ユニティちゃんを動けなくする
            player.GetComponent<UnityChanControlScriptWithRgidBody>().enabled = false;
            //アニメーションをオフにする
            player.GetComponent<Animator>().enabled = false;

            //ゲームオーバー
            isGameOver = true;
        }
    }

    private void Restart()
    {
        Scene loadScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadScene.name);
    }
}