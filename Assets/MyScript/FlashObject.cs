using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashObject : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;
    float _a_color;
    [Tooltip("透明か")] bool isTransparent;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        // 初期は不透明 
        _a_color = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // 透明になったら 
        if(_a_color <= 0)
        {
            isTransparent = true;
        }
        // 不透明になったら 
        else if(_a_color >= 1)
        {
            isTransparent = false;
        }
        
        // 不透明にする 
        if(isTransparent)
        {
            _a_color += Time.deltaTime * 1.5f;
        }
        // 透明にする 
        else if (! isTransparent)
        {
            _a_color -= Time.deltaTime * 1.5f;
        }

        _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, _a_color);
    }
}
