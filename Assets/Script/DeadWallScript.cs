
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityChan;
using UnityEngine.UI;

public class DeadWallScript : MonoBehaviour
{
    //�I�u�W�F�N�g�̑��x
    public float speed;
    //�I�u�W�F�N�g�̉��ړ��̍ő勗��
    public float max_x;

    private int init_direction;

    //unitychan
    public GameObject player;

    //�e�L�X�g
    public GameObject text;

    //�Q�[���I�[�o�[
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

        //�t���[����speed�̒l������x�������Ɉړ�����
        this.gameObject.transform.Translate(speed, 0, 0);

        //Transform��x�̒l�����l�𒴂����Ƃ��Ɍ����𔽑΂ɂ���
        if (this.gameObject.transform.position.x > max_x || this.gameObject.transform.position.x < (-max_x))
        {
            speed *= -1.0f;
            Debug.Log(speed);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        //�ڐG�����I�u�W�F�N�g�����j�e�B�����̂Ƃ�
        if (other.gameObject.name == player.name)
        {
            //�Q�[���I�[�o�[��\������
            text.GetComponent<Text>().text = "GameOver...";
            text.SetActive(true);

            //���j�e�B�����𓮂��Ȃ�����
            player.GetComponent<UnityChanControlScriptWithRgidBody>().enabled = false;
            //�A�j���[�V�������I�t�ɂ���
            player.GetComponent<Animator>().enabled = false;

            //�Q�[���I�[�o�[
            isGameOver = true;
        }
    }

    private void Restart()
    {
        Scene loadScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadScene.name);
    }
}