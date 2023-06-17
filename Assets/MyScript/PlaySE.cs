using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySE : MonoBehaviour
{
    /// <summary>
    /// このスクリプトはAudioSourceがついたプレハブにアタッチする
    /// 使うときは、任意のタイミングで「Instantiate」
    /// </summary>

    AudioSource _sE;
    [SerializeField, Tooltip("クリック時に使うか")] bool _isClick;
    [SerializeField, Tooltip("Instantiateさせて使うか")] bool _isInstantiate;

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
        // こっちはヒエラルキー上にないときは使えない
        if (! _isInstantiate && _isClick)
        {
            // 左クリック時
            if (Input.GetMouseButtonDown(0))
            {
                _sE.Play();
            }
        }
    }
}
