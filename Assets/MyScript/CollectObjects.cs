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
    [Header("[0] Goal�o���@�@�@�@[1] �A�C�e���擾")]
    [SerializeField] GameObject[] _sE;
    [SerializeField] SlideController _slideController;
    [SerializeField] bool _useSlideController;


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

        // �J�����ɘA�����ăX���C�h����I�u�W�F�N�g(�ʒu�������ɕK�v) 
        if(_useSlideController)
            _slideController = GameObject.Find("SlideController").GetComponent<SlideController>();
    }

    void Update()
    {
        // �ݒu�����A�C�e���S�Ă��擾��������s
        if(_count == _itemNum)
        {
            // �uGoal�v��\�� 
            _spriteRenderer.enabled = true;
            // �����蔻�� ���� 
            _collider.enabled = true;
        }
        if(_count == 0)
        {
            // �uGoal�v���\�� 
            _spriteRenderer.enabled = false;
            // �����蔻�� �ڐG�s�� 
            _collider.enabled = false;
        }
        // �uSlideController�v���C���X�y�N�^��ɂ���Ƃ� 
        if (_slideController != null)
        {
            // �ʒu�����������ꂽ��A�A�C�e������������ 
            if(_slideController._resetable == 1)
                _count = 0; 
        }
        _text.text = "���F " + _count + "/" + _itemNum;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Item")
        {
            Destroy(collision.gameObject);
            _count++;
            //_text.text = "���F " + _count + "/" + _itemNum;

            // ������SE
            Instantiate(_sE[1]); 

            if(_count == _itemNum)
                Instantiate(_sE[0]); 
        }
    }
}
