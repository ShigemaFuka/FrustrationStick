using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class GimmickTrigger : MonoBehaviour
{
     GameObject _gimmickMoveControllerObj;
     GimmickMoveController _gimmickMoveController;
    [SerializeField] public bool _isStay;
    [SerializeField, Tooltip("戻る速さ")] float _speed;

    // Start is called before the first frame update
    void Start()
    {
        _isStay = false;
        // これがアタッチされているObjの親オブジェクトの名前を取得 
        string parentObjName = transform.parent.gameObject.name;    // 親オブジェクトはプレハブであるため、名前が変わりがち 
        // GameObject 探したい子オブジェクトが入る = 「GameObject.Find("親オブジェクトの名前 / それと親子関係である、探したい子オブジェクト");」
        _gimmickMoveControllerObj = GameObject.Find(parentObjName + "/TriggerWall");
        //_gimmickMoveControllerObj = GameObject.Find("TriggerWall");
        _gimmickMoveController = _gimmickMoveControllerObj.GetComponent<GimmickMoveController>();
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
            _gimmickMoveController._isPosBack = false;
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            _isStay = false;
            // 初期位置に戻すbool
            _gimmickMoveController._isPosBack = true;
            Invoke("OnMoveFirstPos", 1.0f);
        }
    }

    void OnMoveFirstPos()
    {
        _gimmickMoveControllerObj.gameObject.transform.position = _gimmickMoveController._firstPos;

        /*
        _gimmickMoveControllerObj.gameObject.transform.position 
            = Vector3.MoveTowards(_gimmickMoveControllerObj.transform.position, new Vector3(_gimmickMoveController._firstPos.x, _gimmickMoveController._firstPos.y, _gimmickMoveController._firstPos.z), _speed * Time.deltaTime);
        */
    }
}
