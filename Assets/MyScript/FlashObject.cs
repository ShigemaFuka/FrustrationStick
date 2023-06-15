using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashObject : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;
    float _a_color;
    [Tooltip("������")] bool isTransparent;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        // �����͕s���� 
        _a_color = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // �����ɂȂ����� 
        if(_a_color <= 0)
        {
            isTransparent = true;
        }
        // �s�����ɂȂ����� 
        else if(_a_color >= 1)
        {
            isTransparent = false;
        }
        
        // �s�����ɂ��� 
        if(isTransparent)
        {
            _a_color += Time.deltaTime * 1.5f;
        }
        // �����ɂ��� 
        else if (! isTransparent)
        {
            _a_color -= Time.deltaTime * 1.5f;
        }

        _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, _a_color);
    }
}
