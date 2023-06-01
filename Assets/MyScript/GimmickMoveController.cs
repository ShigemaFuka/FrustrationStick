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
    [SerializeField, Tooltip("�����F�㉺")] bool _is_upDown;
    [SerializeField, Tooltip("�����F���E")] bool _is_leftRight;
    [Tooltip("����̃X�N���v�g���A�^�b�`���ꂽobj�̃|�W")] Vector3 _pos;
    // �����ړ��ł����g���\�� �� �l��obj���ɕύX�ŁB
    [SerializeField, Tooltip("�v���}�C�ł����̈ړ��͈�")] float _xRange = 2.0f;
    [SerializeField, Tooltip("�v���}�C�ł����̈ړ��͈�")] float _yRange = 2.0f;
    bool _xFlag;
    bool _yFlag;
    [SerializeField] bool _flag;


    //transform�𒼐ڕύX���Ă����Ȃ��Q�[���̂��߁A����͂�������
    //      ���@(�N���A���邽�߂ɂ́A�v���C���[���f�����������Ƃ��Ȃ�����)


    void Update()
    {
        _pos = transform.position;

        // �㉺
        if (_is_upDown)
        {
            // �t���O�𑀍�
            if (_pos.y >= _yRange)
                _flag = true;
            else if (_pos.y <= -_yRange)
                _flag = false;

            //�ȉ��t���O�ɂ���Ď��s���e�𕪂��Ă���
            if (_flag)
                transform.position = Vector3.MoveTowards(_pos, new Vector3(_pos.x, -_yRange, 0), _speed * Time.deltaTime);
            else if (!_flag)
                transform.position = Vector3.MoveTowards(_pos, new Vector3(_pos.x, _yRange, 0), _speed * Time.deltaTime);
        }
        // ���E
        else if (_is_leftRight)
        {
            // �t���O�𑀍�
            if (_pos.x >= _yRange)
                _flag = true;
            else if (_pos.x <= -_yRange)
                _flag = false;

            //�ȉ��t���O�ɂ���Ď��s���e�𕪂��Ă���
            if (_flag)
                transform.position = Vector3.MoveTowards(_pos, new Vector3(-_xRange, _pos.y, 0), _speed * Time.deltaTime);
            else if (!_flag)
                transform.position = Vector3.MoveTowards(_pos, new Vector3(_xRange, _pos.y, 0), _speed * Time.deltaTime);
        }
    }


    /*
    void UpDown()
    {
        // �t���O�𑀍�
        if (_pos.y >= _yRange)
            _yFlag = true;
        else if (_pos.y <= -_yRange)
            _yFlag = false;
    }
    void LeftRight()
    {
        // �t���O�𑀍�
        if (_pos.x >= _xRange)
        {
            _xFlag = true;
        }
        else if (_pos.x <= -_xRange)
        {
            _xFlag = false;
        }
    }
    */

}
