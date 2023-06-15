using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class GimmickTrigger : MonoBehaviour
{
     GameObject _gimmickMoveControllerObj;
     GimmickMoveController_2 _gimmickMoveController;
    [SerializeField, Tooltip("TriggerStay��")] public bool _isStay;
    [SerializeField, Tooltip("�߂�܂ł̃C���^�[�o��")] float _interval = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        _isStay = false;

        // ���ꂪ�A�^�b�`����Ă���Obj�̐e�I�u�W�F�N�g�̖��O���擾 
        string parentObjName = transform.parent.gameObject.name;    // �e�I�u�W�F�N�g�̓v���n�u�ł��邽�߁A���O���ς�肪�� (Contains�g�����̂��A��?)
        // GameObject �T�������q�I�u�W�F�N�g������ = �uGameObject.Find("�e�I�u�W�F�N�g�̖��O / ����Ɛe�q�֌W�ł���A�T�������q�I�u�W�F�N�g");�v�B
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
                // ���s�ɃC���^�[�o�������Ă��ǂ������i�v�����j
                Invoke("OnMoveFirstPos", _interval);
            }
        }
    }

    void OnMoveFirstPos()
    {
        // �������Ȃ����APlayer����������ʒu�����Z�b�g������
        _gimmickMoveControllerObj.gameObject.transform.position = _gimmickMoveController._firstPos;

        Vector3 GMCO_Rotaton = _gimmickMoveControllerObj.transform.eulerAngles;
        // ���r���[�ɉ�]�i+�ړ��j���~�܂��Ă�����̂́uRotation.z�v�����Z�b�g
        GMCO_Rotaton.z = 0;
        _gimmickMoveControllerObj.transform.eulerAngles = GMCO_Rotaton;
    }
}
