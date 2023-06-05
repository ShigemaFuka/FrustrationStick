using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyManager : MonoBehaviour
{
    /// <summary>
    /// �����̂��̂�Ώۂɂ������Ȃ�A�z��łȂ��A�e�I�u�W�F�N�g�ɂ�����A�^�b�`���A
    /// 
    /// </summary>

    //�V�[���Ԃł��C���X�^���X�̃I�u�W�F�N�g��1�ɂȂ�悤�ɂ���
    public static DontDestroyManager instance;
    void Awake()
    {
        CheckInstance();
    }
    void CheckInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
