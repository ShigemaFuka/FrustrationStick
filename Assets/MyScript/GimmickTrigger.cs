using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickTrigger : MonoBehaviour
{
    [SerializeField] GimmickMoveController _gimmickMoveController;
    [SerializeField] public bool _isStay;

    // Start is called before the first frame update
    void Start()
    {
        _isStay = false;
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
            //Debug.Log("ÉgÉäÉKÅ[");
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            _isStay = false;
        }
    }
}
