using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickTrigger : MonoBehaviour
{
    GameObject _gimmickMoveControllerObj;
    GimmickMoveController _gimmickMoveController;
    [SerializeField] public bool _isStay;

    // Start is called before the first frame update
    void Start()
    {
        _isStay = false;
        _gimmickMoveControllerObj = GameObject.Find("TriggerWall");
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
            // èâä˙à íuÇ…ñﬂÇ∑bool
            _gimmickMoveController._isPosBack = true;
            Invoke("OnMoveFirstPos", 0.5f);
        }
    }

    void OnMoveFirstPos()
    {
        _gimmickMoveControllerObj.gameObject.transform.position = _gimmickMoveController._firstPos;
    }
}
