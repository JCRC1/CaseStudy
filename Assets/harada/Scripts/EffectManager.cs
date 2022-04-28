using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EffectManager : MonoBehaviour
{
    [SerializeField] GameObject EffectPrefab;
    [SerializeField] Vector3 CreatePos;
    [SerializeField] bool Loop;

    GameObject EffectObject;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR

        // �G�t�F�N�g����������
        if (Keyboard.current.cKey.wasReleasedThisFrame)
        {
            CreateEffect();
        }

        // �G�t�F�N�g����������
        if (Keyboard.current.dKey.wasReleasedThisFrame)
        {
            DestroyEffect();
        }
#endif


    }

    // �G�t�F�N�g�̐���
    void CreateEffect()
    {
        // �C���X�^���X����
        EffectObject = Instantiate(EffectPrefab, CreatePos, Quaternion.identity);

        // ���[�v�ݒ肪�I�t�Ȃ�΃A�j���[�V�����I���ŃC���X�^���X������
        if(!Loop)
        {
            // �C���X�^���X����
            DestroyEffect();
        }
    }


    // �G�t�F�N�g�̏���
    void DestroyEffect()
    {
        // �C���X�^���X����
        GameObject.Destroy(EffectObject, 1.0f);
    }

}
