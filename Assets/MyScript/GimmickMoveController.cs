using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickMoveController : MonoBehaviour
{
    /// <summary>
    /// bool�̑I������œ����ς���
    /// bool�̑I���͎蓮
    /// </summary>

    [SerializeField, Tooltip("���x")] float _speed;
    [SerializeField, Tooltip("��]���x")] float _speedRotate;

    [SerializeField, Header("bool�͈�����^�ɂ��Ďg�p(_isRotation�͕��p�\)"), Tooltip("�����F�㉺")] bool _isUpDown;
    [SerializeField, Tooltip("�����F���E")] bool _isLeftRight;
    [SerializeField, Tooltip("��]")] bool _isRotation;
    [Tooltip("����̃X�N���v�g���A�^�b�`���ꂽobj�̃|�W")] Vector3 _pos;

    // �����ړ��ł����g���\�� �� �l��obj���ɕύX�ŁB
    [SerializeField, Header("�����ŗǂ�"), Tooltip("�v���}�C�ł����̈ړ��͈�")] float _xRange = 2.0f;
    [SerializeField, Tooltip("�v���}�C�ł����̈ړ��͈�")] float _yRange = 2.0f;
    bool _flag;
    [Tooltip("�����̃|�W")] Vector3 _firstPos;
    // �g���K�[�͈͓̔��ɓ���ꂽ��N������������
    [SerializeField, Tooltip("TriggerStay�g������(�蓮����)")] bool _isTrigger;
    [Tooltip("�g���K�[���g���邩")] bool _useTrigger;
    [SerializeField] GameObject triggerObj;


    //transform�𒼐ڕύX���Ă����Ȃ��Q�[���̂��߁A����͂�������
    //      ���@(�N���A���邽�߂ɂ́A�v���C���[���f�����������Ƃ��Ȃ�����)

    // Trigger�I�u�W�F�N�g������΁i�q�I�u�W�F�N�g�j�A

    private void Start()
    {
        // ����ɂ��Aobj�̈ʒu����v���}�C�����ړ��A�ɂł���
        _firstPos = transform.position;

        // ���x���Z�b�g
        //_isTrigger = false;
        if (_isTrigger)
        {
            if (triggerObj == null)
            {
                _useTrigger = false;
                Debug.LogWarning("Trigger�I�u�W�F�N�g���Ȃ�");
            }
            else if (triggerObj)
            {
                _useTrigger = true;
            }
        }
    }

    void Update()
    {
        
        if(_useTrigger == false)
        {
            // �t�c�[�Ɏ��s
            GimmickMove();
        }       
    }

    public void GimmickMove()
    {
        _pos = transform.position;

        // �㉺
        if (_isUpDown)
        {
            // �t���O�𑀍�
            if (_pos.y >= _firstPos.y + _yRange)
                _flag = true;
            else if (_pos.y <= _firstPos.y - _yRange)
                _flag = false;

            //�ȉ��t���O�ɂ���Ď��s���e�𕪂��Ă���
            if (_flag)
                transform.position = Vector3.MoveTowards(_pos, new Vector3(_pos.x, _firstPos.y - _yRange, 0), _speed * Time.deltaTime);
            else if (!_flag)
                transform.position = Vector3.MoveTowards(_pos, new Vector3(_pos.x, _firstPos.y + _yRange, 0), _speed * Time.deltaTime);
        }
        // ���E
        else if (_isLeftRight)
        {
            // �t���O�𑀍�
            if (_pos.x >= _firstPos.x + _xRange)
                _flag = true;
            else if (_pos.x <= _firstPos.x - _xRange)
                _flag = false;

            //�ȉ��t���O�ɂ���Ď��s���e�𕪂��Ă���
            if (_flag)
                transform.position = Vector3.MoveTowards(_pos, new Vector3(_firstPos.x - _xRange, _pos.y, 0), _speed * Time.deltaTime);
            else if (!_flag)
                transform.position = Vector3.MoveTowards(_pos, new Vector3(_firstPos.x + _xRange, _pos.y, 0), _speed * Time.deltaTime);
        }
        // ��]
        if (_isRotation)
        {
            gameObject.transform.Rotate(0, 0, _speedRotate * Time.deltaTime);
        }
    }
}
