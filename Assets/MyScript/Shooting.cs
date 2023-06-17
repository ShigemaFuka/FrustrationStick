using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField, Tooltip("弾のプレハブ")] GameObject _prefab;
    //N秒ごとに弾を生成するための時間管理
    [SerializeField, Tooltip("生成時間")] float _makingTime = 0.1f;
    [Tooltip("現在の時間")] public float _currentTime = 0;
    float _intervalTime; 
    // 0°から始まるので0で初期化 
    [Tooltip("角度")] float deg = 0;
    [SerializeField, Tooltip("生成の間隔(角度)")] float _degInterval = 30.0f; 
    //２周分より大きくなったら既に円は完成しているので弾は作成しない
    [SerializeField, Tooltip("弾を作り終えたかどうか")] bool isMadeObj = false;
    [SerializeField, Tooltip("周数")] int _lap;
    [SerializeField, Tooltip("このObjからの半径")] float _radius = 1.0f;
    [SerializeField, Tooltip("Prefabの移動の強さ")] float _power;
    [Tooltip("生成したものが入ってる")] GameObject _obj;

    private void Start()
    {
        _intervalTime = 2;
    }

    // Update is called once per frame
    void Update()
    {
        _currentTime += Time.deltaTime;
        if (isMadeObj)
        {
            // 一定時間待ったら、再び生成できるようにする 
            if (_intervalTime < _currentTime)
            {
                _currentTime = 0;
                isMadeObj = false;
                _intervalTime = Random.Range(1.0f, 7.0f);
            }
        }
        else if (_makingTime < _currentTime)
        {
            _currentTime = 0;
            
            //まだ円周上に弾を作り終えていなければ弾を作成する
            if (!isMadeObj)
            {
                //角度degからラジアンを作成
                float radian = deg * Mathf.Deg2Rad;      // 「Deg2Rad」= 2π/360
                //ラジアンを用いて、sinとcosを求める
                float sin = Mathf.Sin(radian);
                float cos = Mathf.Cos(radian);

                //円周上の点を求める
                //円の中心座標に半径(= _radius)をかけたcos(= x)とsin(= y)を足す
                Vector3 pos = this.gameObject.transform.position + new Vector3(cos * _radius, sin * _radius, 0);
                //弾の作成
                _obj = Instantiate(_prefab);
                //弾を求めた円周上の座標に置く
                _obj.transform.position = pos;

                Rigidbody2D rb = _obj.GetComponent<Rigidbody2D>();
                // thisに対し、外に向かって発射 
                Vector3 shootVector = _obj.transform.position - this.gameObject.transform.position; 
                rb.velocity = shootVector * _power; 
                // 消す処理はプレハブ内にある 

                //角度を_degInterval°ずつ足す 
                deg += _degInterval;
                // _lap周分よりも大きくなったら、弾を作らないのでフラグをtrueにしておく 
                if (deg > 360 * _lap - _degInterval)
                {
                    isMadeObj = true;
                    deg = 0;
                }
            }
        }
    }
}
