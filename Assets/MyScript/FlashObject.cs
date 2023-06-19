using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlashObject : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;
    float _a_color;
    [Tooltip("透明か")] bool isTransparent;
    [Space]
    [SerializeField, Header("コライダのisTriggerを真に")] bool _useTrigger;
    [SerializeField, Tooltip("点滅速度")] float _speed; 

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        // 初期は不透明 
        _a_color = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // ふつーに使う 
        if (! _useTrigger)
            Flash();
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        // （子オブジェクト）特定エリアに侵入中だけ実行 
        if (coll.gameObject.tag == "Player")
            Flash(_speed); 
    }

    // デフォルト 
    void Flash()
    {
        // 透明になったら 
        if (_a_color <= 0)
        {
            isTransparent = true;
        }
        // 不透明になったら 
        else if (_a_color >= 1)
        {
            isTransparent = false;
        }

        if (isTransparent)
        {
            // 不透明にする 
            _a_color += Time.deltaTime * 1.5f;
        }
        else if (!isTransparent)
        {
            // 透明にする 
            _a_color -= Time.deltaTime * 1.5f;
        }
        _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, _a_color);
    }


    // 点滅速度の指定アリなら
    void Flash(float speed)
    {
        // 透明になったら 
        if (_a_color <= 0)
        {
            isTransparent = true;
        }
        // 不透明になったら 
        else if (_a_color >= 1)
        {
            isTransparent = false;
        }

        if (isTransparent)
        {
            // 不透明にする 
            _a_color += Time.deltaTime * speed;
        }
        else if (!isTransparent)
        {
            // 透明にする 
            _a_color -= Time.deltaTime * speed;
        }
        _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, _a_color);
    }
}
