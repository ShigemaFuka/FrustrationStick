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
    [SerializeField, Tooltip("往復：上下")] bool _is_upDown;
    [SerializeField, Tooltip("往復：左右")] bool _is_leftRight;
    [Tooltip("これのスクリプトがアタッチされたobjのポジ")] Vector3 _pos;
    // 往復移動でしか使わん予定 ＆ 値はobj毎に変更で。
    [SerializeField, Tooltip("プラマイでｘ軸の移動範囲")] float _xRange = 2.0f;
    [SerializeField, Tooltip("プラマイでｙ軸の移動範囲")] float _yRange = 2.0f;
    bool _xFlag;
    bool _yFlag;
    [SerializeField] bool _flag;


    //transformを直接変更しても問題ないゲームのため、今回はそうする
    //      →　(クリアするためには、プレイヤーが素早く動くことがないから)


    void Update()
    {
        _pos = transform.position;

        // 上下
        if (_is_upDown)
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
        else if (_is_leftRight)
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
    }


    /*
    void UpDown()
    {
        // フラグを操作
        if (_pos.y >= _yRange)
            _yFlag = true;
        else if (_pos.y <= -_yRange)
            _yFlag = false;
    }
    void LeftRight()
    {
        // フラグを操作
        if (_pos.x >= _xRange)
        {
            _xFlag = true;
        }
        else if (_pos.x <= -_xRange)
        {
            _xFlag = false;
        }
    }
    */

}
