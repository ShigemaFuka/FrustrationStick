using UnityEngine;

/// <summary>
/// 一定時間おきに指定したプレハブから GameObject を生成するコンポーネント
/// </summary>
public class SpawnObject : MonoBehaviour
{
    [SerializeField, Tooltip("一定時間おきに生成する GameObject の元となるプレハブ")] GameObject _prefab;
    [SerializeField, Tooltip("生成する間隔（秒）")] float _interval;
    [SerializeField, Tooltip("true の場合、開始時にまず生成する")] bool _generateOnStart;
    [Tooltip("タイマー計測用変数")] float _timer;
    [SerializeField, Tooltip("Destroyするか")] bool _destroyiInThis; 
    [SerializeField] float _destroyTime;
    [Range(0.5f,4f), SerializeField] float _scale;
    [SerializeField, Tooltip("プレハブのスピードを変えたいか")] bool _isChangeSpeed;
    [SerializeField, Tooltip("上書きしたい速度")] float _speed;

    void Start()
    {
        Transform transform = _prefab.GetComponent<Transform>();

        if(_isChangeSpeed)
        {
            // 今回発射物は皆「Bullet」が付いているからこうできる 
            Bullet bullet = _prefab.GetComponent<Bullet>();
            bullet._speed = this._speed;
        }
        if (_generateOnStart)
        {
            _timer = _interval;
        }
    }

    GameObject _obj;
    void Update()
    {
        _timer += Time.deltaTime;

        // 「経過時間」が「生成する間隔」を超えたら
        if (_timer > _interval)
        {
            _timer = 0;    // タイマーをリセットしている
            _obj = Instantiate(_prefab, this.transform.position, Quaternion.identity);
            // 同じプレハブでも、スケールをさまざまにできる 
            _obj.transform.localScale = new Vector3(_scale, _scale, 1f);
        }
        if(_destroyiInThis)
            Destroy(_obj, _destroyTime);
    }
}
