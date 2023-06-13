using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class GimmickTrigger : MonoBehaviour
{
     GameObject _gimmickMoveControllerObj;
     GimmickMoveController _gimmickMoveController;
    [SerializeField] public bool _isStay;
    [SerializeField, Tooltip("�߂鑬��")] float _speed;

    // Start is called before the first frame update
    void Start()
    {
        _isStay = false;
        // ���ꂪ�A�^�b�`����Ă���Obj�̐e�I�u�W�F�N�g�̖��O���擾 
        string parentObjName = transform.parent.gameObject.name;    // �e�I�u�W�F�N�g�̓v���n�u�ł��邽�߁A���O���ς�肪�� 
        // GameObject �T�������q�I�u�W�F�N�g������ = �uGameObject.Find("�e�I�u�W�F�N�g�̖��O / ����Ɛe�q�֌W�ł���A�T�������q�I�u�W�F�N�g");�v
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
            // �����ʒu�ɖ߂�bool
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
