using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]

public class SpawnObjectTrigger : MonoBehaviour
{
    [SerializeField, Tooltip("生成したいobj")] GameObject _spawnObject;
    [SerializeField, Tooltip("トータルで何個生成させるか")] int _spawnCount;
    [Tooltip("「Homing」と共有して使用")] public　static int _count;

    void Start()
    {
        _count = 0;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        // N個だけ生成 
        if(coll.gameObject.tag == "Player")
        {
            // 「_spawnCount」個未満だったら生成可能 
            if (_count < _spawnCount)
            {
                Instantiate(_spawnObject, this.gameObject.transform);
                _count++;
            }
        }
    }

}
