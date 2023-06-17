using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneContr : MonoBehaviour
{
    //「Back」ボタンがクリックされたら
    public void OnClickBack(string name)
    {
        SceneManager.LoadScene(name);
    }
}
