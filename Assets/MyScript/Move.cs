using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; //TextMeshProを扱う際に必要
using UnityEngine.UI;
using Unity.VisualScripting;

public class Move : MonoBehaviour
{
    // 「start」がクリックされたらplayer追尾開始
    
    [Tooltip("「S」のクリック判定のフラグ")] public bool _FlgBtn; 
    [Tooltip("playerの画像コンポーネント")] public SpriteRenderer _sr;  
    [SerializeField] Text _deathText;
    [SerializeField, Tooltip("接触時に再生")] AudioSource _himei;
    [SerializeField, Tooltip("クリック音のobj")] GameObject _clickObjPrefab;
    CircleCollider2D _circleCollider2D;
    [Tooltip("死んだ回数")] int count = 0;

    void Start()
    {
        _FlgBtn = false;     //まだ追尾しない

        //「S」をクリックされるまで画像を非表示にしておく
        _sr = GetComponent<SpriteRenderer>();
        _sr.enabled = false;

        count = 0;

        // 位置を初期化 
        GameObject startObj = GameObject.Find("Start");
        transform.position = startObj.transform.position;

        // 
        GameObject deathTextObj = GameObject.Find("DeathText (Legacy)");
        _deathText = deathTextObj.GetComponent<Text>();

        _himei = GetComponent<AudioSource>();
        _circleCollider2D = GetComponent<CircleCollider2D>();
        // コライダOFF
        _circleCollider2D.enabled = false;
    }

    void Update()
    {
        //countを一旦文字列に変えてdTextに代入
        var dText = count.ToString();

        //「Death」と「死んだ回数」を表示
        _deathText.text = "Death\n" + dText; 
        if (_FlgBtn == true)
        {
            //以下でカーソル追従
            var mousePosition = Input.mousePosition;
            //Debug.Log(mousePosition);
            mousePosition.z = 10.0f;
            transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Update()のif文の移動停止
        _FlgBtn = false;
        //画像非表示
        _sr.enabled = false;
        // コライダOFF
        _circleCollider2D.enabled = false;
        count += 1; 
        _himei.Play();
        Debug.Log("死んだ回数："+count);
        Debug.Log(collision.gameObject.name + "に当たったよ");
    }

    //「S」をクリックされたら実行
    public void OnClickStart()
    {
        //Update()のif文の移動開始
        _FlgBtn = true;
        //画像表示
        _sr.enabled = true;
        // コライダON
        _circleCollider2D.enabled = true; 
    }
    
    //「Back」ボタンがクリックされたら
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);

        //Update()のif文の移動開始
        _FlgBtn = false;
        //画像表示
        _sr.enabled = false;
        // コライダON
        _circleCollider2D.enabled = false;

        Debug.Log("ChangeScene!!");
    }



}
