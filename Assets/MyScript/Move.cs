using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; //TextMeshProを扱う際に必要
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    // 「start」がクリックされたらplayer追尾開始
    
    public bool FlgBtn;         //「S」のクリック判定のフラグ
    public SpriteRenderer sr;   //playerの画像コンポーネント
    [SerializeField] //TextMeshProUGUI deathText;
    Text deathText;

    void Start()
    {
        FlgBtn = false;     //まだ追尾しない
        //「S」をクリックされるまで画像を非表示にしておく
        sr.enabled = false;
        count = 0;
        GameObject startObj = GameObject.Find("Start");
        transform.position = startObj.transform.position;
    }

    void Update()
    {
        //countを一旦文字列に変えてdTextに代入
        var dText = count.ToString();

        //「Death」と「死んだ回数」を表示
        deathText.text = "Death\n" + dText;
        if (FlgBtn == true)
        {
            //以下でカーソル追従
            var mousePosition = Input.mousePosition;
            //Debug.Log(mousePosition);
            mousePosition.z = 10.0f;
            transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        }
    }

    int count = 0;
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Update()のif文の移動停止
        FlgBtn = false;
        //画像非表示
        sr.enabled = false;
        count += 1;
        Debug.Log("死んだ回数："+count);
        Debug.Log(collision.gameObject.name + "に当たったよ");
    }

    //「S」をクリックされたら実行
    public void OnClickStart()
    {
        //Update()のif文の移動開始
        FlgBtn = true;
        //画像表示
        sr.enabled = true;
    }
    
    //「Back」ボタンがクリックされたら
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
        Debug.Log("ChangeScene!!");
    }



}
