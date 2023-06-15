using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Bullet : MonoBehaviour
{
    [SerializeField] int _speed; 

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.left * _speed;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 1.0f);
    }
}
