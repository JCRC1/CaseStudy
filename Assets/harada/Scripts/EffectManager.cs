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


    GameObject EffectObject;
    Animator effectAnimator;
    AnimatorClipInfo[] effectAnimatorClipInfo;


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
            CreateEffect(90.0f);
        }

        // �G�t�F�N�g����������
        if (Keyboard.current.dKey.wasReleasedThisFrame)
        {
            DestroyEffect();
        }
#endif

        // Chase��true�Ȃ�transform�̍��W�ɒǏ]����
        if(Chase && EffectObject != null)
        {
            EffectObject.transform.position = CreatePosT.position;
        }


    }

    // �G�t�F�N�g�̐���
    // effectRotate...��]���������p�x�̒l�iZ��]�j
    public void CreateEffect(float effectRotate)
    {
        // �C���X�^���X����
        // Transform���ݒ肳��Ă��Ȃ���Ύw�肵�����W�Ő���
        if (CreatePosT != null)
        {
            EffectObject = Instantiate(EffectPrefab, CreatePosT.transform.position, Quaternion.Euler(0, 0, effectRotate));
        }
        else
        {
            EffectObject = Instantiate(EffectPrefab, CreatePosV, Quaternion.Euler(0, 0, effectRotate));
        }

        
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
        // �A�j���[�V�����N���b�v�̎擾
        effectAnimator = EffectObject.GetComponent<Animator>();
        effectAnimatorClipInfo = effectAnimator.GetCurrentAnimatorClipInfo(0);

        //Debug.Log(effectAnimatorClipInfo[0].clip.length);

        // �C���X�^���X����
        GameObject.Destroy(EffectObject, effectAnimatorClipInfo[0].clip.length);
    }

}
