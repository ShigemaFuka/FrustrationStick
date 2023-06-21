using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SlideController : MonoBehaviour
{
    [Tooltip("�����ʒu�̔z��")] Vector3[] _initialPoses;
    [SerializeField] float _speed = 1.0f;
    [SerializeField] GameObject[] _targets;
    [SerializeField, Tooltip("x�������̈ړ��͈�(����)")] float _range;
    [Tooltip("�ʒu������������^�C�~���O�i���񂾉񐔁j")] public int _resetTime;
    [Tooltip("int�^�̖�����bool�ȕϐ�(0=�^)")] public int _resetable; 

    // Start is called before the first frame update
    void Start()
    {
        // �ړ���������Obj���̏����ʒu���Z�b�g 
        _initialPoses = new Vector3[_targets.Length]; 
        for(var i = 0; i < _initialPoses.Length; i++)
        {
            _initialPoses[i] = _targets[i].transform.position;
        }
        _resetable = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var target in _targets)
        {
            // �E�ֈړ� 
            if (target.gameObject.transform.position.x <= _range)
                target.gameObject.transform.position += Vector3.right * Time.deltaTime * _speed;
        }
    }

    //int i = 0; 
    public void ResetPosition()
    {
        // �ʒu������ 
        for (var i = 0; i < _targets.Length; i++)
        {
            _targets[i].gameObject.transform.position = _initialPoses[i];
        }
        // �ʒu�������@�g�p�s�� 
        _resetable = 1; 
    }
}
