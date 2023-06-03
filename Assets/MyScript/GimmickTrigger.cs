using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickTrigger : MonoBehaviour
{
    [SerializeField] GimmickMoveController _gimmickMoveController;
    [SerializeField] bool _isStay;

    // Start is called before the first frame update
    void Start()
    {
        _isStay = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(_isStay)
        {
            _gimmickMoveController.GimmickMove();
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            _isStay = true;
            Debug.Log("�g���K�[");
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        _isStay = false;
    }
}
