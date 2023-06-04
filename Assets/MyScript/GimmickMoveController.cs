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
    [SerializeField, Tooltip("回転速度")] float _speedRotate;

    [SerializeField, Header("boolは一つだけ真にして使用(_isRotationは併用可能)"), Tooltip("往復：上下")] bool _isUpDown;
    [SerializeField, Tooltip("往復：左右")] bool _isLeftRight;
    [SerializeField, Tooltip("回転")] bool _isRotation;
    [Tooltip("これのスクリプトがアタッチされたobjのポジ")] Vector3 _pos;

    // 往復移動でしか使わん予定 ＆ 値はobj毎に変更で。
    [SerializeField, Header("正数で良い"), Tooltip("プラマイでｘ軸の移動範囲")] float _xRange = 2.0f;
    [SerializeField, Tooltip("プラマイでｙ軸の移動範囲")] float _yRange = 2.0f;
    bool _flag;
    [Tooltip("初期のポジ")] Vector3 _firstPos;

    // トリガーの範囲内に入られたら起動したいから
    [Header("トリガー使う場合はポジをきりの良い値にしないと、なぜかうまく動作しない(0.6とかはダメだった)")]
    [SerializeField, Tooltip("TriggerStay使う許可(手動アサイン)")] bool _isTrigger;
    [Tooltip("トリガーが使えるか")] bool _useTrigger;
    [SerializeField, Tooltip("Triggerオブジェクト(手動アサイン)")] GameObject triggerObj;
     GimmickTrigger _gimmickTrigger;


    //transformを直接変更しても問題ないゲームのため、今回はそうする
    //      →　(クリアするためには、プレイヤーが素早く動くことがないから)

    private void Start()
    {
        // これにより、objの位置からプラマイいくつ移動、にできる
        _firstPos = transform.position;

        if (_isTrigger)
        {
            if (triggerObj == null)
            {
                _useTrigger = false;
                Debug.LogWarning("Triggerオブジェクトがない");
            }
            else if (triggerObj)
            {
                _useTrigger = true;
                _gimmickTrigger = triggerObj.GetComponent<GimmickTrigger>();
            }
        }
    }

    void Update()
    {

        if (_useTrigger == false)
        {
            // フツーに実行
            GimmickMove();
        }
        else if(_useTrigger && _gimmickTrigger._isStay)
        {
            GimmickMove();
            //Debug.Log("GimmickMove");

        }
    }

    public void GimmickMove()
    {
        _pos = this.transform.position;

        // 上下
        if (_isUpDown)
        {
            // フラグを操作
            if (_pos.y >= _firstPos.y + _yRange)
                _flag = true;
            else if (_pos.y <= _firstPos.y - _yRange)
                _flag = false;

            //以下フラグによって実行内容を分けている
            if (_flag)
                transform.position = Vector3.MoveTowards(_pos, new Vector3(_pos.x, _firstPos.y - _yRange, 0), _speed * Time.deltaTime);
            else if (!_flag)
                transform.position = Vector3.MoveTowards(_pos, new Vector3(_pos.x, _firstPos.y + _yRange, 0), _speed * Time.deltaTime);

        }
        // 左右
        else if (_isLeftRight)
        {
            // フラグを操作
            if (_pos.x >= _firstPos.x + _xRange)
                _flag = true;
            else if (_pos.x <= _firstPos.x - _xRange)
                _flag = false;

            //以下フラグによって実行内容を分けている
            if (_flag)
                transform.position = Vector3.MoveTowards(_pos, new Vector3(_firstPos.x - _xRange, _pos.y, 0), _speed * Time.deltaTime);
            else if (!_flag)
                transform.position = Vector3.MoveTowards(_pos, new Vector3(_firstPos.x + _xRange, _pos.y, 0), _speed * Time.deltaTime);
        }
        // 回転
        if (_isRotation)
        {
            gameObject.transform.Rotate(0, 0, _speedRotate * Time.deltaTime);
        }
    }
}
