using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickRotation : MonoBehaviour
{
    [SerializeField] float speed;
    
    // �M�~�b�N�����̏�Ŏ��]������
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, 0, speed*Time.deltaTime);
    }
}
