using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class GoalManagement : MonoBehaviour
{
    // �X�e�[�W���O�Ɣԍ�
    private string sceneName;
    private string levelNum;

    private void Start()
    {
        //�@�X�e�[�W���O�Ɣԍ��Q�b�g
        sceneName = SceneManager.GetActiveScene().name;
        levelNum = sceneName.Replace("stage", "");
    }

    //�@���肠���
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�@�v���C���[���S�[���ɓ��B����
        if (collision.tag == "Player")
        {
            //�@PlayerPrefs��ݒ�
            PlayerPrefs.SetInt("Stage_" + levelNum + "_Clear", 1);
            Debug.Log("���x���N���A�IPlayerPrefs�@Stage_" + levelNum + "_Clear�@���P�ɐݒ肳���Ă�");

            //�@�Q�[���N���A

        }
    }
}
