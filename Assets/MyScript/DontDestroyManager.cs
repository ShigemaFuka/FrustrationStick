using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyManager : MonoBehaviour
{
    /// <summary>
    /// 複数のものを対象にしたいなら、配列でなく、親オブジェクトにこれをアタッチし、
    /// 
    /// </summary>

    //シーン間でもインスタンスのオブジェクトが1つになるようにする
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
