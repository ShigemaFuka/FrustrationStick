using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlashObject : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;
    float _a_color;
    [Tooltip("������")] bool isTransparent;
    [Space]
    [SerializeField, Header("�R���C�_��isTrigger��^��")] bool _useTrigger;
    [SerializeField, Tooltip("�_�ő��x")] float _speed; 

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        // �����͕s���� 
        _a_color = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // �ӂ[�Ɏg�� 
        if (! _useTrigger)
            Flash();
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        // �i�q�I�u�W�F�N�g�j����G���A�ɐN�����������s 
        if (coll.gameObject.tag == "Player")
            Flash(_speed); 
    }

    // �f�t�H���g 
    void Flash()
    {
        // �����ɂȂ����� 
        if (_a_color <= 0)
        {
            isTransparent = true;
        }
        // �s�����ɂȂ����� 
        else if (_a_color >= 1)
        {
            isTransparent = false;
        }

        if (isTransparent)
        {
            // �s�����ɂ��� 
            _a_color += Time.deltaTime * 1.5f;
        }
        else if (!isTransparent)
        {
            // �����ɂ��� 
            _a_color -= Time.deltaTime * 1.5f;
        }
        _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, _a_color);
    }


    // �_�ő��x�̎w��A���Ȃ�
    void Flash(float speed)
    {
        // �����ɂȂ����� 
        if (_a_color <= 0)
        {
            isTransparent = true;
        }
        // �s�����ɂȂ����� 
        else if (_a_color >= 1)
        {
            isTransparent = false;
        }

        if (isTransparent)
        {
            // �s�����ɂ��� 
            _a_color += Time.deltaTime * speed;
        }
        else if (!isTransparent)
        {
            // �����ɂ��� 
            _a_color -= Time.deltaTime * speed;
        }
        _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, _a_color);
    }
}
