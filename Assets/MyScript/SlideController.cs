using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SlideController : MonoBehaviour
{
    [Tooltip("初期位置の配列")] Vector3[] _initialPoses;
    [SerializeField] float _speed = 1.0f;
    [SerializeField] GameObject[] _targets;
    [SerializeField, Tooltip("x軸方向の移動範囲(正数)")] float _range;
    [Tooltip("位置を初期化するタイミング（死んだ回数）")] public int _resetTime;
    [Tooltip("int型の役割はboolな変数(0=真)")] public int _resetable; 

    // Start is called before the first frame update
    void Start()
    {
        // 移動させたいObj分の初期位置をセット 
        _initialPoses = new Vector3[_targets.Length]; 
        for(var i = 0; i < _initialPoses.Length; i++)
        {
            _initialPoses[i] = _targets[i].transform.position;
        }
        _resetable = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var target in _targets)
        {
            // 右へ移動 
            if (target.gameObject.transform.position.x <= _range)
                target.gameObject.transform.position += Vector3.right * Time.deltaTime * _speed;
        }
    }

    //int i = 0; 
    public void ResetPosition()
    {
        // 位置初期化 
        for (var i = 0; i < _targets.Length; i++)
        {
            _targets[i].gameObject.transform.position = _initialPoses[i];
        }
        // 位置初期化　使用不可に 
        _resetable = 1; 
    }
}
