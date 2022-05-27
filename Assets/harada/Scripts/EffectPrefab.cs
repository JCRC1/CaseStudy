using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPrefab : MonoBehaviour
{
    bool NoChase;
    float timer;
    float animTime;
    Vector3 noChasePosition;


    // Start is called before the first frame update
    void Start()
    {
        // �A�j���[�V�������Ԃ��擾
        animTime = this.gameObject.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.length;
        timer = animTime;
        Debug.Log(animTime);

        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // �G�t�F�N�g���Ń^�C�}�[����
        if (this.gameObject.activeSelf)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                this.gameObject.SetActive(false);

                timer = animTime;
            }
        }

        // NoChase��true�Ȃ�transform�̍��W�ɒǏ]����
        if (NoChase && noChasePosition != null)
        {
            this.gameObject.transform.position = noChasePosition;
        }
    }


    public void EffectON()
    {
        this.gameObject.SetActive(true);
    }


    public void SetEffectPosition(Vector3 setVector)
    {
        NoChase = true;

        noChasePosition = setVector;
    }
}
