using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneContr : MonoBehaviour
{
    //�uBack�v�{�^�����N���b�N���ꂽ��
    public void OnClickBack(string name)
    {
        SceneManager.LoadScene(name);
    }
}
