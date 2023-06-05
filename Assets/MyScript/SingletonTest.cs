using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SingletonTest : MonoBehaviour
{


    // オブジェクトをstatic（静的）にする
    public static SingletonTest instance;
    [SerializeField, Tooltip("シーン遷移先で重複せずに破棄させたくない物")] GameObject[] gameObjects;
    public static GameObject[] gameObjects2 = null;

    // オブジェクトが生成されたとき、
    private void Awake()
    {
        if (instance == null)
        {
            // シーン遷移しても破棄されないようにする
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // 二重で起動されないようにする
            Destroy(gameObject);
        }
    }
}
