using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickMoveController_2 : MonoBehaviour
{
    /// <summary>
    /// bool�̑I������œ����ς���
    /// bool�̑I���͎蓮
    /// </summary>

    [SerializeField, Tooltip("���x")] float _speed;
    [SerializeField, Tooltip("��]���x")] float _speedRotate;
    [Header("�����p")]
    [SerializeField, Tooltip("�������邩 �uGimmickTrigger�v�Ŏg�p")] public bool _roundTrip;
    [SerializeField, Tooltip("�����F�㉺")] bool _isUpDown;
    [SerializeField, Tooltip("�����F���E")] bool _isLeftRight;
    [Space]
    [SerializeField, Tooltip("���Ɉړ�(�蓮�Ő^�U)")] bool _isDown;
    [SerializeField, Tooltip("��Ɉړ�(�蓮�Ő^�U)")] bool _isUp;
    [SerializeField, Tooltip("���Ɉړ�(�蓮�Ő^�U)")] bool _isLeft;
    [SerializeField, Tooltip("��Ɉړ�(�蓮�Ő^�U)")] bool _isRight;
    [Space]
    [SerializeField, Tooltip("��] �uGimmickTrigger�v�Ŏg�p")] public bool _isRotation;
    [Tooltip("����̃X�N���v�g���A�^�b�`���ꂽobj�̃|�W")] Vector3 _pos;

    // �����ړ��ł����g���\�� �� �l��obj���ɕύX�ŁB
    [SerializeField, Header("�����ŗǂ�"), Tooltip("�v���}�C�ł����̈ړ��͈�")] float _xRange = 2.0f;
    [SerializeField, Tooltip("�v���}�C�ł����̈ړ��͈�")] float _yRange = 2.0f;
    [Tooltip("�������̏��")] bool _flagY;
    [Tooltip("�������̏��")] bool _flagX;
    [Header("�蓮�ŕύX�����"), Tooltip("�����̃|�W")] public Vector3 _firstPos;

    // �g���K�[�͈͓̔��ɓ���ꂽ��N������������
    [Header("�g���K�[�g���ꍇ�̓|�W������̗ǂ��l�ɂ��Ȃ��ƁA�Ȃ������܂����삵�Ȃ�(0.6�Ƃ��̓_��������)")]
    [SerializeField, Tooltip("TriggerStay�g������(�蓮�A�T�C��)")] bool _isTrigger;
    [Tooltip("�g���K�[���g���邩")] bool _useTrigger;
    [SerializeField, Header("_isTrigger��^�ɂ��Ă�Ȃ�蓮�A�T�C��"), Tooltip("Trigger�I�u�W�F�N�g")] GameObject _triggerObj;
    GimmickTrigger _gimmickTrigger;



    //transform�𒼐ڕύX���Ă����Ȃ��Q�[���̂��߁A����͂�������
    //      ���@(�N���A���邽�߂ɂ́A�v���C���[���f�����������Ƃ��Ȃ�����)

    private void Start()
    {
        // ����ɂ��Aobj�̈ʒu����v���}�C�����ړ��A�ɂł���
        _firstPos = transform.position;

        _roundTrip = false;

        if (_isTrigger)
        {
            if (_triggerObj == null)
            {
                _useTrigger = false;
                Debug.LogWarning("Trigger�I�u�W�F�N�g���Ȃ�");
            }
            else if (_triggerObj)
            {
                _useTrigger = true;
                _gimmickTrigger = _triggerObj.GetComponent<GimmickTrigger>();

                // ������
                //_isPosBack = false;
            }
        }
    }

    void Update()
    {
        if (_useTrigger == false)
        {
            // �t�c�[�Ɏ��s
            GimmickMove();
        }
        else if(_useTrigger && _gimmickTrigger._isStay)
        {
            // trigger��stay���Ă鎞����
            GimmickMove();
        }
    }

    public void GimmickMove()
    {
        _pos = this.transform.position;
        
        // ���ֈړ�
        if (_isDown)
            transform.position = Vector3.MoveTowards(_pos, new Vector3(_pos.x, _firstPos.y - _yRange, 0), _speed * Time.deltaTime);
        // ��ֈړ�
        else if (_isUp)
            transform.position = Vector3.MoveTowards(_pos, new Vector3(_pos.x, _firstPos.y + _yRange, 0), _speed * Time.deltaTime);
        // ���ֈړ�
        else if (_isLeft)
            transform.position = Vector3.MoveTowards(_pos, new Vector3(_firstPos.x - _xRange, _pos.y, 0), _speed * Time.deltaTime);
        // �E�ֈړ�
        else if (_isRight)
            transform.position = Vector3.MoveTowards(_pos, new Vector3(_firstPos.x + _xRange, _pos.y, 0), _speed * Time.deltaTime);

        // �ȉ��@�㉺
        if (_isUpDown)
        {
            // ��������p�̃t���O�𑀍�
            if (_pos.y >= _firstPos.y + _yRange)
                // ����܂ŏ�ɍs������
                _flagY = true;
            else if (_pos.y <= _firstPos.y - _yRange)
                // ����܂ŉ��ɍs������
                _flagY = false;

            //// �����ړ� 
            // ���ֈړ�
            if (_flagY)
                transform.position = Vector3.MoveTowards(_pos, new Vector3(_pos.x, _firstPos.y - _yRange, 0), _speed * Time.deltaTime);
            // ��ֈړ�
            else if (!_flagY)
                transform.position = Vector3.MoveTowards(_pos, new Vector3(_pos.x, _firstPos.y + _yRange, 0), _speed * Time.deltaTime);

            _roundTrip = true;
        }
        // �ȉ��@���E
        else if (_isLeftRight)
        {
            // ��������p�̃t���O�𑀍�
            if (_pos.x >= _firstPos.x + _xRange)
                // ����܂ŉE�ɍs������
                _flagX = true;
            else if (_pos.x <= _firstPos.x - _xRange)
                // ����܂ō��ɍs������
                _flagX = false;

            //// �����ړ� 
            // ���ֈړ�
            if (_flagX)
                transform.position = Vector3.MoveTowards(_pos, new Vector3(_firstPos.x - _xRange, _pos.y, 0), _speed * Time.deltaTime);
            // �E�ֈړ�
            else if (!_flagX)
                transform.position = Vector3.MoveTowards(_pos, new Vector3(_firstPos.x + _xRange, _pos.y, 0), _speed * Time.deltaTime);

            _roundTrip = true;
        }

        // ��]
        if (_isRotation)
        {
            gameObject.transform.Rotate(0, 0, _speedRotate * Time.deltaTime);
        }
        

        /*
        // �㉺
        if (_isUpDown)
        {
            // �t���O�𑀍�
            if (_pos.y >= _firstPos.y + _yRange)
                _flag = true;
            else if (_pos.y <= _firstPos.y - _yRange)
                _flag = false;

            // ����������
            if (!_dontRoundTrip)
            { 
                //�ȉ��t���O�ɂ���Ď��s���e�𕪂��Ă���

                // ���ֈړ�
                if (_flag)
                    transform.position = Vector3.MoveTowards(_pos, new Vector3(_pos.x, _firstPos.y - _yRange, 0), _speed * Time.deltaTime);
                // ��ֈړ�
                else if (!_flag)
                    transform.position = Vector3.MoveTowards(_pos, new Vector3(_pos.x, _firstPos.y + _yRange, 0), _speed * Time.deltaTime);
            }
            else if(_dontRoundTrip)
            {
                // ���ֈړ�
                if(!_isPosBack && _isDown)
                    transform.position = Vector3.MoveTowards(_pos, new Vector3(_pos.x, _firstPos.y - _yRange, 0), _speed  * Time.deltaTime);
                // ��ֈړ�
                else if (!_isPosBack && _isUp)
                {
                    transform.position = Vector3.MoveTowards(_pos, new Vector3(_pos.x, _firstPos.y + _yRange, 0), _speed * Time.deltaTime);
                }
            }
        }
        // ���E
        else if (_isLeftRight)
        {
            // �t���O�𑀍�
            if (_pos.x >= _firstPos.x + _xRange)
                _flag = true;
            else if (_pos.x <= _firstPos.x - _xRange)
                _flag = false;

            // ����������
            if (!_dontRoundTrip)
            {
                //�ȉ��t���O�ɂ���Ď��s���e�𕪂��Ă���
                if (_flag)
                    transform.position = Vector3.MoveTowards(_pos, new Vector3(_firstPos.x - _xRange, _pos.y, 0), _speed * Time.deltaTime);
                else if (!_flag)
                    transform.position = Vector3.MoveTowards(_pos, new Vector3(_firstPos.x + _xRange, _pos.y, 0), _speed * Time.deltaTime);
            }
            else if(_dontRoundTrip)
            {
                // ���ֈړ�
                if (!_isPosBack && _isLeft)
                    transform.position = Vector3.MoveTowards(_pos, new Vector3(_firstPos.x - _xRange, _pos.y, 0), _speed * Time.deltaTime);
                // �E�ֈړ�
                else if (!_isPosBack && _isRight)
                {
                    transform.position = Vector3.MoveTowards(_pos, new Vector3(_firstPos.x + _xRange, _pos.y, 0), _speed * Time.deltaTime);
                }
            }
        }
        // ��]
        if (_isRotation)
        {
            gameObject.transform.Rotate(0, 0, _speedRotate * Time.deltaTime);
        }
        */
    }
}
