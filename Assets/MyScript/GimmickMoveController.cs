using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickMoveController : MonoBehaviour
{
    /// <summary>
    /// boolの選択次第で動作を変える
    /// boolの選択は手動
    /// </summary>

    [SerializeField, Tooltip("速度")] float _speed;
    [SerializeField, Header("boolは一つだけ真にして使用"), Tooltip("往復：上下")] bool _isUpDown;
    [SerializeField, Tooltip("往復：左右")] bool _isLeftRight;
    [SerializeField, Tooltip("回転")] bool _isRotation;
    [Tooltip("これのスクリプトがアタッチされたobjのポジ")] Vector3 _pos;
    // 往復移動でしか使わん予定 ＆ 値はobj毎に変更で。
    [SerializeField, Header("正数で良い"), Tooltip("プラマイでｘ軸の移動範囲")] float _xRange = 2.0f;
    [SerializeField, Tooltip("プラマイでｙ軸の移動範囲")] float _yRange = 2.0f;
    bool _flag;


    //transformを直接変更しても問題ないゲームのため、今回はそうする
    //      →　(クリアするためには、プレイヤーが素早く動くことがないから)


    void Update()
    {
        _pos = transform.position;

        // 上下
        if (_isUpDown)
        {
            // フラグを操作
            if (_pos.y >= _yRange)
                _flag = true;
            else if (_pos.y <= -_yRange)
                _flag = false;

            //以下フラグによって実行内容を分けている
            if (_flag)
                transform.position = Vector3.MoveTowards(_pos, new Vector3(_pos.x, -_yRange, 0), _speed * Time.deltaTime);
            else if (!_flag)
                transform.position = Vector3.MoveTowards(_pos, new Vector3(_pos.x, _yRange, 0), _speed * Time.deltaTime);
        }
        // 左右
        else if (_isLeftRight)
        {
            // フラグを操作
            if (_pos.x >= _yRange)
                _flag = true;
            else if (_pos.x <= -_yRange)
                _flag = false;

            //以下フラグによって実行内容を分けている
            if (_flag)
                transform.position = Vector3.MoveTowards(_pos, new Vector3(-_xRange, _pos.y, 0), _speed * Time.deltaTime);
            else if (!_flag)
                transform.position = Vector3.MoveTowards(_pos, new Vector3(_xRange, _pos.y, 0), _speed * Time.deltaTime);
        }
        // 回転
        else if(_isRotation)
        {
            gameObject.transform.Rotate(0, 0, _speed * Time.deltaTime);
        }
    }
}
