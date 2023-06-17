using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Bullet : MonoBehaviour
{
    [SerializeField] float _destroyTime;
    [Header("à»â∫é©êgÇ≈à⁄ìÆÇ∑ÇÈÇ»ÇÁì¸óÕ")] 
    [SerializeField, Tooltip("é©êgÇ≈à⁄ìÆÇ∑ÇÈÇ©")] bool _isMoveSelf;
    [SerializeField] bool _toLeft;
    [SerializeField] bool _toRight;
    [SerializeField] bool _toUp;
    [SerializeField] bool _toDown;
    [SerializeField] public float _speed; 
    

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (_isMoveSelf)
        {
            if (_toLeft)
                rb.velocity = Vector3.left * _speed;
            if (_toRight)
                rb.velocity = Vector3.right * _speed;
            if (_toUp)
                rb.velocity = Vector3.up * _speed;
            if (_toDown)
                rb.velocity = Vector3.down * _speed;
        }
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
