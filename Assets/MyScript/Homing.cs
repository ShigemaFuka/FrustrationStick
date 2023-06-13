using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{
    // 「Instantiate」で生成させて使う　←　非表示のPlayerを追尾してしまわないように

    [SerializeField] float _speed;
    GameObject _target;

    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(_target.transform.position.x, _target.transform.position.y), _speed * Time.deltaTime);
    }
}
