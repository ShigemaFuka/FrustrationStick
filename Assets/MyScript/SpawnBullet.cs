using UnityEngine;

/// <summary>
/// 一定時間おきに指定したプレハブから GameObject を生成するコンポーネント
/// </summary>
public class SpawnBullet : MonoBehaviour
{
    [SerializeField, Tooltip("一定時間おきに生成する GameObject の元となるプレハブ")] GameObject _prefab;
    [SerializeField, Tooltip("生成する間隔（秒）")] float _interval;
    [SerializeField, Tooltip("true の場合、開始時にまず生成する")] bool _generateOnStart;
    [Tooltip("タイマー計測用変数")] float _timer;

    void Start()
    {
        if (_generateOnStart)
        {
            _timer = _interval;
        }
    }

    void Update()
    {
        _timer += Time.deltaTime;

        // 「経過時間」が「生成する間隔」を超えたら
        if (_timer > _interval)
        {
            _timer = 0;    // タイマーをリセットしている
            Instantiate(_prefab, this.transform.position, Quaternion.identity);
        }
    }
}
