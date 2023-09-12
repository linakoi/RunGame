
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class WallScript : MonoBehaviour
{
    //�I�u�W�F�N�g�̑��x
    public float speed;
    //�I�u�W�F�N�g�̉��ړ��̍ő勗��
    public float max_x;

    public float min_x;


    private int init_direction;

     
    private void Start()
    {
        //�ړ���������������_���Ɍ��肵�Ă���
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

        //�t���[����speed�̒l������x�������Ɉړ�����
        this.gameObject.transform.Translate(speed, 0, 0);

        //Transform��x�̒l�����l�𒴂����Ƃ��Ɍ����𔽑΂ɂ���
        if (this.gameObject.transform.position.x > max_x || this.gameObject.transform.position.x < min_x) {
            speed *= -1.0f;
            Debug.Log(speed);
        }
    }
}