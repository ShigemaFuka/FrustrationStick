using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneContr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //「Back」ボタンがクリックされたら
    public void OnClickBack(string name)
    {
        SceneManager.LoadScene(name);
        Debug.Log("Back");
    }


}
