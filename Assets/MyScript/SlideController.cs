using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideController : MonoBehaviour
{
    //Vector3 _initialPos;
    [SerializeField, Header("���l���傫���قǂ������")] float _speed = 1.0f;
    [SerializeField] GameObject[] _targets;
    [SerializeField, Tooltip("x�������̈ړ��͈�(����)")] float _range;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        foreach (var target in _targets)
        {
            // �E�ֈړ� 
            if(target.gameObject.transform.position.x <= _range)
                target.gameObject.transform.position += Vector3.right * Time.deltaTime / _speed;
        }
        
    }
}
