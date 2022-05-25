using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EffectManager : MonoBehaviour
{
    [SerializeField] GameObject EffectPrefab;
    [SerializeField] Vector3 CreatePosV;
    [SerializeField] Transform CreatePosT;
    [SerializeField] bool Loop;
    [SerializeField] bool Chase;

    public float timer = 0.0f;
    float animTime = 0.0f;
    Animator effectAnimator;


    // Start is called before the first frame update
    void Start()
    {
        // �A�j���[�V�����N���b�v�̎擾
        effectAnimator = EffectPrefab.GetComponent<Animator>();

        // �A�j���[�V�������Ԃ̎擾
        animTime = effectAnimator.GetCurrentAnimatorClipInfo(0).Length;
        timer = animTime;

        // �G�t�F�N�g�v���n�u���I�t�ݒ�
        SetActiveEffectPrefab(false);
    }


    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR

        // �G�t�F�N�g����������
        if (Keyboard.current.cKey.wasReleasedThisFrame)
        {
            SetActiveEffectPrefab(true);
        }

#endif

        // Chase��true�Ȃ�transform�̍��W�ɒǏ]����
        if (Chase)
        {
            EffectPrefab.transform.position = CreatePosT.position;
        }

        // �G�t�F�N�g���Ń^�C�}�[����
        if (EffectPrefab.activeSelf)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                SetActiveEffectPrefab(false);

                timer = animTime;
            }
        }

    }


    // �G�t�F�N�g�̍��W�̃Z�b�g
    public void SetCreatePosV(Vector3 setVector)
    {
        EffectPrefab.transform.position = setVector;
    }


    // �G�t�F�N�g�̐ݒ�
    public void SetActiveEffectPrefab(bool setBool)
    {
        EffectPrefab.SetActive(setBool);
    }
}
