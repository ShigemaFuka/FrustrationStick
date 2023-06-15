using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class GimmickTrigger : MonoBehaviour
{
     GameObject _gimmickMoveControllerObj;
     GimmickMoveController_2 _gimmickMoveController;
    [SerializeField, Tooltip("TriggerStayか")] public bool _isStay;
    [SerializeField, Tooltip("戻るまでのインターバル")] float _interval = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        _isStay = false;

        // これがアタッチされているObjの親オブジェクトの名前を取得 
        string parentObjName = transform.parent.gameObject.name;    // 親オブジェクトはプレハブであるため、名前が変わりがち (Contains使うものもアリ?)
        // GameObject 探したい子オブジェクトが入る = 「GameObject.Find("親オブジェクトの名前 / それと親子関係である、探したい子オブジェクト");」。
        _gimmickMoveControllerObj = GameObject.Find(parentObjName + "/TriggerWall");
        _gimmickMoveController = _gimmickMoveControllerObj.GetComponent<GimmickMoveController_2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            _isStay = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            _isStay = false;

            if (_gimmickMoveController._resetPos)
            {
                // 実行にインターバルあっても良いかも（要調整）
                Invoke("OnMoveFirstPos", _interval);
            }
        }
    }

    void OnMoveFirstPos()
    {
        // 往復しないが、Playerが消えたら位置をリセットしたい
        _gimmickMoveControllerObj.gameObject.transform.position = _gimmickMoveController._firstPos;

        Vector3 GMCO_Rotaton = _gimmickMoveControllerObj.transform.eulerAngles;
        // 中途半端に回転（+移動）が止まっているものの「Rotation.z」をリセット
        GMCO_Rotaton.z = 0;
        _gimmickMoveControllerObj.transform.eulerAngles = GMCO_Rotaton;
    }
}
