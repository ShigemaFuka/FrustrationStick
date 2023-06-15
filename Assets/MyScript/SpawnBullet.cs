using UnityEngine;

/// <summary>
/// ��莞�Ԃ����Ɏw�肵���v���n�u���� GameObject �𐶐�����R���|�[�l���g
/// </summary>
public class SpawnBullet : MonoBehaviour
{
    [SerializeField, Tooltip("��莞�Ԃ����ɐ������� GameObject �̌��ƂȂ�v���n�u")] GameObject _prefab;
    [SerializeField, Tooltip("��������Ԋu�i�b�j")] float _interval;
    [SerializeField, Tooltip("true �̏ꍇ�A�J�n���ɂ܂���������")] bool _generateOnStart;
    [Tooltip("�^�C�}�[�v���p�ϐ�")] float _timer;

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

        // �u�o�ߎ��ԁv���u��������Ԋu�v�𒴂�����
        if (_timer > _interval)
        {
            _timer = 0;    // �^�C�}�[�����Z�b�g���Ă���
            Instantiate(_prefab, this.transform.position, Quaternion.identity);
        }
    }
}
