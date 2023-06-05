using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SingletonTest : MonoBehaviour
{


    // �I�u�W�F�N�g��static�i�ÓI�j�ɂ���
    public static SingletonTest instance;
    [SerializeField, Tooltip("�V�[���J�ڐ�ŏd�������ɔj�����������Ȃ���")] GameObject[] gameObjects;
    public static GameObject[] gameObjects2 = null;

    // �I�u�W�F�N�g���������ꂽ�Ƃ��A
    private void Awake()
    {
        if (instance == null)
        {
            // �V�[���J�ڂ��Ă��j������Ȃ��悤�ɂ���
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // ��d�ŋN������Ȃ��悤�ɂ���
            Destroy(gameObject);
        }
    }
}
