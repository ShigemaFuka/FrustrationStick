using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectObjects : MonoBehaviour
{
    // N個アイテムゲットしたらGoalを出現させる
    // Playerにアタッチ 

    [Tooltip("設置したアイテムの数")] int _itemNum;
    int _count;
    [Tooltip("Goalのスプライトレンダラ")] SpriteRenderer _spriteRenderer;
    [Tooltip("Goalのコライダ")] Collider2D _collider;
    [Tooltip("条件表示")] Text _text;
    [Header("[0] Goal出現　　　　[1] アイテム取得")]
    [SerializeField] GameObject[] _sE;
    [SerializeField] SlideController _slideController;
    [SerializeField] bool _useSlideController;


    void Start()
    {
        _count = 0;

        GameObject[]  _itemGameObjects = GameObject.FindGameObjectsWithTag("Item");
        _itemNum = _itemGameObjects.Length;

        // 条件未達成なら非表示
        _spriteRenderer = GameObject.FindWithTag("Goal").GetComponent<SpriteRenderer>();
        _spriteRenderer.enabled = false;

        // 条件未達成なら接触不可
        _collider = GameObject.FindWithTag("Goal").GetComponent<Collider2D>();
        _collider.enabled = false;

        // 初期化 
        _text = GameObject.Find("Message").GetComponent<Text>();
        _text.text = "●： " + _count + "/" + _itemNum;

        // カメラに連動してスライドするオブジェクト(位置初期化に必要) 
        if(_useSlideController)
            _slideController = GameObject.Find("SlideController").GetComponent<SlideController>();
    }

    void Update()
    {
        // 設置したアイテム全てを取得したら実行
        if(_count == _itemNum)
        {
            // 「Goal」を表示 
            _spriteRenderer.enabled = true;
            // 当たり判定 復活 
            _collider.enabled = true;
        }
        if(_count == 0)
        {
            // 「Goal」を非表示 
            _spriteRenderer.enabled = false;
            // 当たり判定 接触不可 
            _collider.enabled = false;
        }
        // 「SlideController」がインスペクタ上にあるとき 
        if (_slideController != null)
        {
            // 位置が初期化されたら、アイテム数も初期化 
            if(_slideController._resetable == 1)
                _count = 0; 
        }
        _text.text = "●： " + _count + "/" + _itemNum;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Item")
        {
            Destroy(collision.gameObject);
            _count++;
            //_text.text = "●： " + _count + "/" + _itemNum;

            // ここでSE
            Instantiate(_sE[1]); 

            if(_count == _itemNum)
                Instantiate(_sE[0]); 
        }
    }
}
