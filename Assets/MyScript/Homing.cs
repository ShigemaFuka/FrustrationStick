using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Homing : MonoBehaviour
{
    // �uInstantiate�v�Ő��������Ďg���@���@��\����Player��ǔ����Ă��܂�Ȃ��悤��

    [SerializeField] float _speed;
    GameObject _target;
    SpriteRenderer _renderer;

    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
        _renderer = _target.GetComponent<SpriteRenderer>();

        // �ⓚ���p��5�b�o��������� 
        Destroy(gameObject, 5.0f);
    }

    void Update()
    {
        // Player���\������Ă���Ƃ������A����
        if (_renderer.enabled)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(_target.transform.position.x, _target.transform.position.y), _speed * Time.deltaTime);
        }
        // Player��\���Ȃ玩�g��j��
        else if (!_renderer.enabled)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        // �X�|�[�����ꂽObj�̌������炷
        SpawnHomingObj._count--;
    }
}
