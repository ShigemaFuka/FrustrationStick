using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScale : MonoBehaviour
{
    Vector3 _defaultScalse;
    [SerializeField] float _resetTime; 
    GameObject _target;
    bool _resetScale = false;

    private void Start()
    {
        _defaultScalse = GameObject.FindWithTag("Player").transform.localScale;
    }

    void Update()
    {
        if (_resetScale)
        {
            Invoke("ResetScale", _resetTime);
            _resetScale = false; 
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            _target = coll.gameObject;
            _target.transform.localScale = new Vector3(_target.transform.localScale.x * 1.2f, _target.transform.localScale.y * 1.2f);
            _resetScale = true;
        }
    }

    void ResetScale()
    {
        _target.transform.localScale = _defaultScalse;
    }
}
