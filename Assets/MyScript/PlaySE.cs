using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySE : MonoBehaviour
{
    /// <summary>
    /// ���̃X�N���v�g��AudioSource�������v���n�u�ɃA�^�b�`����
    /// �g���Ƃ��́A�C�ӂ̃^�C�~���O�ŁuInstantiate�v
    /// </summary>

    AudioSource _sE;
    [SerializeField, Tooltip("�N���b�N���Ɏg����")] bool _isClick;
    [SerializeField, Tooltip("Instantiate�����Ďg����")] bool _isInstantiate;

    void Start()
    {
        _sE = GetComponent<AudioSource>();
        if(_isInstantiate)
        {
            _sE.Play();
            Destroy(gameObject, 1);
        }
    }

    private void Update()
    {
        // �������̓q�G�����L�[��ɂȂ��Ƃ��͎g���Ȃ�
        if (! _isInstantiate && _isClick)
        {
            // ���N���b�N��
            if (Input.GetMouseButtonDown(0))
            {
                _sE.Play();
            }
        }
    }
}
