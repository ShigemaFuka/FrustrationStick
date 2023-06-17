using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField, Tooltip("�e�̃v���n�u")] GameObject _prefab;
    //N�b���Ƃɒe�𐶐����邽�߂̎��ԊǗ�
    [SerializeField, Tooltip("��������")] float _makingTime = 0.1f;
    [Tooltip("���݂̎���")] public float _currentTime = 0;
    float _intervalTime; 
    // 0������n�܂�̂�0�ŏ����� 
    [Tooltip("�p�x")] float deg = 0;
    [SerializeField, Tooltip("�����̊Ԋu(�p�x)")] float _degInterval = 30.0f; 
    //�Q�������傫���Ȃ�������ɉ~�͊������Ă���̂Œe�͍쐬���Ȃ�
    [SerializeField, Tooltip("�e�����I�������ǂ���")] bool isMadeObj = false;
    [SerializeField, Tooltip("����")] int _lap;
    [SerializeField, Tooltip("����Obj����̔��a")] float _radius = 1.0f;
    [SerializeField, Tooltip("Prefab�̈ړ��̋���")] float _power;
    [Tooltip("�����������̂������Ă�")] GameObject _obj;

    private void Start()
    {
        _intervalTime = 2;
    }

    // Update is called once per frame
    void Update()
    {
        _currentTime += Time.deltaTime;
        if (isMadeObj)
        {
            // ��莞�ԑ҂�����A�Ăѐ����ł���悤�ɂ��� 
            if (_intervalTime < _currentTime)
            {
                _currentTime = 0;
                isMadeObj = false;
                _intervalTime = Random.Range(1.0f, 7.0f);
            }
        }
        else if (_makingTime < _currentTime)
        {
            _currentTime = 0;
            
            //�܂��~����ɒe�����I���Ă��Ȃ���Βe���쐬����
            if (!isMadeObj)
            {
                //�p�xdeg���烉�W�A�����쐬
                float radian = deg * Mathf.Deg2Rad;      // �uDeg2Rad�v= 2��/360
                //���W�A����p���āAsin��cos�����߂�
                float sin = Mathf.Sin(radian);
                float cos = Mathf.Cos(radian);

                //�~����̓_�����߂�
                //�~�̒��S���W�ɔ��a(= _radius)��������cos(= x)��sin(= y)�𑫂�
                Vector3 pos = this.gameObject.transform.position + new Vector3(cos * _radius, sin * _radius, 0);
                //�e�̍쐬
                _obj = Instantiate(_prefab);
                //�e�����߂��~����̍��W�ɒu��
                _obj.transform.position = pos;

                Rigidbody2D rb = _obj.GetComponent<Rigidbody2D>();
                // this�ɑ΂��A�O�Ɍ������Ĕ��� 
                Vector3 shootVector = _obj.transform.position - this.gameObject.transform.position; 
                rb.velocity = shootVector * _power; 
                // ���������̓v���n�u���ɂ��� 

                //�p�x��_degInterval�������� 
                deg += _degInterval;
                // _lap���������傫���Ȃ�����A�e�����Ȃ��̂Ńt���O��true�ɂ��Ă��� 
                if (deg > 360 * _lap - _degInterval)
                {
                    isMadeObj = true;
                    deg = 0;
                }
            }
        }
    }
}
