using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectObjects : MonoBehaviour
{
    // N�A�C�e���Q�b�g������Goal���o��������
    // Player�ɃA�^�b�` 

    [Tooltip("�ݒu�����A�C�e���̐�")] int _itemNum;
    int _count;
    [Tooltip("Goal�̃X�v���C�g�����_��")] SpriteRenderer _spriteRenderer;
    [Tooltip("Goal�̃R���C�_")] Collider2D _collider;
    [Tooltip("�����\��")] Text _text; 
    [SerializeField] AudioSource[] _audioSource; 
    //[SerializeField, Tooltip("0�FGoal�o���A1�F�A�C�e���擾")] AudioClip[] _audioClips; 

    void Start()
    {
        _count = 0;

        GameObject[]  _itemGameObjects = GameObject.FindGameObjectsWithTag("Item");
        _itemNum = _itemGameObjects.Length;

        // �������B���Ȃ��\��
        _spriteRenderer = GameObject.FindWithTag("Goal").GetComponent<SpriteRenderer>();
        _spriteRenderer.enabled = false;

        // �������B���Ȃ�ڐG�s��
        _collider = GameObject.FindWithTag("Goal").GetComponent<Collider2D>();
        _collider.enabled = false;

        // ������ 
        _text = GameObject.Find("Message").GetComponent<Text>();
        _text.text = "���F " + _count + "/" + _itemNum;

        //_audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // �ݒu�����A�C�e���S�Ă��擾��������s
        if(_count == _itemNum)
        {
            // ������SE
            _audioSource[0].PlayOneShot(_audioSource[0].clip);

            // �uGoal�v��\�� 
            _spriteRenderer.enabled = true;
            // �����蔻�� ���� 
            _collider.enabled = true;

            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Item")
        {
            Destroy(collision.gameObject);
            _count++;
            _text.text = "���F " + _count + "/" + _itemNum;

            // ������SE
            _audioSource[1].PlayOneShot(_audioSource[1].clip); 
        }
    }
}
