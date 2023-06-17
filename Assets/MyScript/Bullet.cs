using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Bullet : MonoBehaviour
{
    [SerializeField] float _destroyTime;
    [Header("�ȉ����g�ňړ�����Ȃ����")] 
    [SerializeField, Tooltip("���g�ňړ����邩")] bool _isMoveSelf; 
    [SerializeField] int _speed; 
    

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if(_isMoveSelf)
        rb.velocity = Vector3.left * _speed;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, _destroyTime);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(gameObject); 
    }
}
