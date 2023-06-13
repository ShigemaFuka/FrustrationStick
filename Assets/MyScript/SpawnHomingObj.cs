using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]

public class SpawnHomingObj : MonoBehaviour
{
    [SerializeField, Tooltip("����������obj")] GameObject _spawnObject;
    [SerializeField, Tooltip("�g�[�^���ŉ����������邩")] int _spawnCount;
    int _count;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        // N�������� 
        if(coll.gameObject.tag == "Player")
        {
            // �u_spawnCount�v�����������琶���\ 
            if (_count < _spawnCount)
            {
                Instantiate(_spawnObject, this.gameObject.transform);
                _count++;
            }
        }
    }

}
