using UnityEngine;

/// <summary>
/// ��莞�Ԃ����Ɏw�肵���v���n�u���� GameObject �𐶐�����R���|�[�l���g
/// </summary>
public class SpawnObject : MonoBehaviour
{
    [SerializeField, Tooltip("��莞�Ԃ����ɐ������� GameObject �̌��ƂȂ�v���n�u")] GameObject _prefab;
    [SerializeField, Tooltip("��������Ԋu�i�b�j")] float _interval;
    [SerializeField, Tooltip("true �̏ꍇ�A�J�n���ɂ܂���������")] bool _generateOnStart;
    [Tooltip("�^�C�}�[�v���p�ϐ�")] float _timer;
    [SerializeField, Tooltip("Destroy���邩")] bool _destroyiInThis; 
    [SerializeField] float _destroyTime;
    [Range(0.5f,4f), SerializeField] float _scale;
    [SerializeField, Tooltip("�v���n�u�̃X�s�[�h��ς�������")] bool _isChangeSpeed;
    [SerializeField, Tooltip("�㏑�����������x")] float _speed;

    void Start()
    {
        Transform transform = _prefab.GetComponent<Transform>();

        if(_isChangeSpeed)
        {
            // ���񔭎˕��͊F�uBullet�v���t���Ă��邩�炱���ł��� 
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

        // �u�o�ߎ��ԁv���u��������Ԋu�v�𒴂�����
        if (_timer > _interval)
        {
            _timer = 0;    // �^�C�}�[�����Z�b�g���Ă���
            _obj = Instantiate(_prefab, this.transform.position, Quaternion.identity);
            // �����v���n�u�ł��A�X�P�[�������܂��܂ɂł��� 
            _obj.transform.localScale = new Vector3(_scale, _scale, 1f);
        }
        if(_destroyiInThis)
            Destroy(_obj, _destroyTime);
    }
}
