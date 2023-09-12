
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class WallScript : MonoBehaviour
{
    //オブジェクトの速度
    public float speed;
    //オブジェクトの横移動の最大距離
    public float max_x;

    public float min_x;


    private int init_direction;

     
    private void Start()
    {
        //移動する方向をランダムに決定している
        init_direction = Random.Range(0, 2);
        if(init_direction == 0)
        {
            speed *= -1.0f;
        }
    }


    // Update is called once per frame
    void Update()
    {
        Debug.Log(speed);

        //フレーム毎speedの値分だけx軸方向に移動する
        this.gameObject.transform.Translate(speed, 0, 0);

        //Transformのxの値が一定値を超えたときに向きを反対にする
        if (this.gameObject.transform.position.x > max_x || this.gameObject.transform.position.x < min_x) {
            speed *= -1.0f;
            Debug.Log(speed);
        }
    }
}