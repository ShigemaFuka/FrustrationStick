using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{
    // 「Instantiate」で生成させて使う　←　非表示のPlayerを追尾してしまわないように

    [SerializeField] float _speed;
    GameObject _target;
    SpriteRenderer _renderer;

    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
        _renderer = _target.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Playerが表示されているときだけ、動く
        if (_renderer.enabled)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(_target.transform.position.x, _target.transform.position.y), _speed * Time.deltaTime);
        }
        // Player非表示なら自身を破棄
        else if (!_renderer.enabled)
        {
            // スポーンされたて存在するObjの個数を減らす
            SpawnHomingObj._count --;

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            // スポーンされたて存在するObjの個数を減らす
            SpawnHomingObj._count --;

            Destroy(gameObject);
        }
    }
}
