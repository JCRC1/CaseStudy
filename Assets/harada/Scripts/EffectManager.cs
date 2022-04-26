using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EffectManager : MonoBehaviour
{
    [SerializeField] GameObject EffectPrefab;
    [SerializeField] Vector3 CreatePos;

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
#endif


    }

    // �G�t�F�N�g�̐���
    void CreateEffect()
    {
        // �C���X�^���X����
        Instantiate(EffectPrefab, CreatePos, Quaternion.identity);
    }

}
