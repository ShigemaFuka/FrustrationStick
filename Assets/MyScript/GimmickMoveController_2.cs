using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickMoveController_2 : MonoBehaviour
{
    /// <summary>
    /// boolの選択次第で動作を変える
    /// boolの選択は手動
    /// </summary>

    [SerializeField, Tooltip("速度")] float _speed;
    [SerializeField, Tooltip("回転速度")] float _speedRotate;
    [Header("往復用")]
    [SerializeField, Tooltip("往復するか 「GimmickTrigger」で使用")] public bool _roundTrip;
    [SerializeField, Tooltip("往復：上下")] bool _isUpDown;
    [SerializeField, Tooltip("往復：左右")] bool _isLeftRight;
    [Space]
    [SerializeField, Tooltip("下に移動(手動で真偽)")] bool _isDown;
    [SerializeField, Tooltip("上に移動(手動で真偽)")] bool _isUp;
    [SerializeField, Tooltip("下に移動(手動で真偽)")] bool _isLeft;
    [SerializeField, Tooltip("上に移動(手動で真偽)")] bool _isRight;
    [Space]
    [SerializeField, Tooltip("回転 「GimmickTrigger」で使用")] public bool _isRotation;
    [Tooltip("これのスクリプトがアタッチされたobjのポジ")] Vector3 _pos;

    // 往復移動でしか使わん予定 ＆ 値はobj毎に変更で。
    [SerializeField, Header("正数で良い"), Tooltip("プラマイでｘ軸の移動範囲")] float _xRange = 2.0f;
    [SerializeField, Tooltip("プラマイでｙ軸の移動範囲")] float _yRange = 2.0f;
    [Tooltip("往復時の上限")] bool _flagY;
    [Tooltip("往復時の上限")] bool _flagX;
    [Header("手動で変更するな"), Tooltip("初期のポジ")] public Vector3 _firstPos;

    // トリガーの範囲内に入られたら起動したいから
    [Header("トリガー使う場合はポジをきりの良い値にしないと、なぜかうまく動作しない(0.6とかはダメだった)")]
    [SerializeField, Tooltip("TriggerStay使う許可(手動アサイン)")] bool _isTrigger;
    [Tooltip("トリガーが使えるか")] bool _useTrigger;
    [SerializeField, Header("_isTriggerを真にしてるなら手動アサイン"), Tooltip("Triggerオブジェクト")] GameObject _triggerObj;
    GimmickTrigger _gimmickTrigger;



    //transformを直接変更しても問題ないゲームのため、今回はそうする
    //      →　(クリアするためには、プレイヤーが素早く動くことがないから)

    private void Start()
    {
        // これにより、objの位置からプラマイいくつ移動、にできる
        _firstPos = transform.position;

        _roundTrip = false;

        if (_isTrigger)
        {
            if (_triggerObj == null)
            {
                _useTrigger = false;
                Debug.LogWarning("Triggerオブジェクトがない");
            }
            else if (_triggerObj)
            {
                _useTrigger = true;
                _gimmickTrigger = _triggerObj.GetComponent<GimmickTrigger>();

                // 初期化
                //_isPosBack = false;
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
            // triggerにstayしてる時だけ
            GimmickMove();
        }
    }

    public void GimmickMove()
    {
        _pos = this.transform.position;
        
        // 下へ移動
        if (_isDown)
            transform.position = Vector3.MoveTowards(_pos, new Vector3(_pos.x, _firstPos.y - _yRange, 0), _speed * Time.deltaTime);
        // 上へ移動
        else if (_isUp)
            transform.position = Vector3.MoveTowards(_pos, new Vector3(_pos.x, _firstPos.y + _yRange, 0), _speed * Time.deltaTime);
        // 左へ移動
        else if (_isLeft)
            transform.position = Vector3.MoveTowards(_pos, new Vector3(_firstPos.x - _xRange, _pos.y, 0), _speed * Time.deltaTime);
        // 右へ移動
        else if (_isRight)
            transform.position = Vector3.MoveTowards(_pos, new Vector3(_firstPos.x + _xRange, _pos.y, 0), _speed * Time.deltaTime);

        // 以下　上下
        if (_isUpDown)
        {
            // 往復する用のフラグを操作
            if (_pos.y >= _firstPos.y + _yRange)
                // 上限まで上に行ったら
                _flagY = true;
            else if (_pos.y <= _firstPos.y - _yRange)
                // 上限まで下に行ったら
                _flagY = false;

            //// 往復移動 
            // 下へ移動
            if (_flagY)
                transform.position = Vector3.MoveTowards(_pos, new Vector3(_pos.x, _firstPos.y - _yRange, 0), _speed * Time.deltaTime);
            // 上へ移動
            else if (!_flagY)
                transform.position = Vector3.MoveTowards(_pos, new Vector3(_pos.x, _firstPos.y + _yRange, 0), _speed * Time.deltaTime);

            _roundTrip = true;
        }
        // 以下　左右
        else if (_isLeftRight)
        {
            // 往復する用のフラグを操作
            if (_pos.x >= _firstPos.x + _xRange)
                // 上限まで右に行ったら
                _flagX = true;
            else if (_pos.x <= _firstPos.x - _xRange)
                // 上限まで左に行ったら
                _flagX = false;

            //// 往復移動 
            // 左へ移動
            if (_flagX)
                transform.position = Vector3.MoveTowards(_pos, new Vector3(_firstPos.x - _xRange, _pos.y, 0), _speed * Time.deltaTime);
            // 右へ移動
            else if (!_flagX)
                transform.position = Vector3.MoveTowards(_pos, new Vector3(_firstPos.x + _xRange, _pos.y, 0), _speed * Time.deltaTime);

            _roundTrip = true;
        }

        // 回転
        if (_isRotation)
        {
            gameObject.transform.Rotate(0, 0, _speedRotate * Time.deltaTime);
        }
        

        /*
        // 上下
        if (_isUpDown)
        {
            // フラグを操作
            if (_pos.y >= _firstPos.y + _yRange)
                _flag = true;
            else if (_pos.y <= _firstPos.y - _yRange)
                _flag = false;

            // 往復させる
            if (!_dontRoundTrip)
            { 
                //以下フラグによって実行内容を分けている

                // 下へ移動
                if (_flag)
                    transform.position = Vector3.MoveTowards(_pos, new Vector3(_pos.x, _firstPos.y - _yRange, 0), _speed * Time.deltaTime);
                // 上へ移動
                else if (!_flag)
                    transform.position = Vector3.MoveTowards(_pos, new Vector3(_pos.x, _firstPos.y + _yRange, 0), _speed * Time.deltaTime);
            }
            else if(_dontRoundTrip)
            {
                // 下へ移動
                if(!_isPosBack && _isDown)
                    transform.position = Vector3.MoveTowards(_pos, new Vector3(_pos.x, _firstPos.y - _yRange, 0), _speed  * Time.deltaTime);
                // 上へ移動
                else if (!_isPosBack && _isUp)
                {
                    transform.position = Vector3.MoveTowards(_pos, new Vector3(_pos.x, _firstPos.y + _yRange, 0), _speed * Time.deltaTime);
                }
            }
        }
        // 左右
        else if (_isLeftRight)
        {
            // フラグを操作
            if (_pos.x >= _firstPos.x + _xRange)
                _flag = true;
            else if (_pos.x <= _firstPos.x - _xRange)
                _flag = false;

            // 往復させる
            if (!_dontRoundTrip)
            {
                //以下フラグによって実行内容を分けている
                if (_flag)
                    transform.position = Vector3.MoveTowards(_pos, new Vector3(_firstPos.x - _xRange, _pos.y, 0), _speed * Time.deltaTime);
                else if (!_flag)
                    transform.position = Vector3.MoveTowards(_pos, new Vector3(_firstPos.x + _xRange, _pos.y, 0), _speed * Time.deltaTime);
            }
            else if(_dontRoundTrip)
            {
                // 左へ移動
                if (!_isPosBack && _isLeft)
                    transform.position = Vector3.MoveTowards(_pos, new Vector3(_firstPos.x - _xRange, _pos.y, 0), _speed * Time.deltaTime);
                // 右へ移動
                else if (!_isPosBack && _isRight)
                {
                    transform.position = Vector3.MoveTowards(_pos, new Vector3(_firstPos.x + _xRange, _pos.y, 0), _speed * Time.deltaTime);
                }
            }
        }
        // 回転
        if (_isRotation)
        {
            gameObject.transform.Rotate(0, 0, _speedRotate * Time.deltaTime);
        }
        */
    }
}
