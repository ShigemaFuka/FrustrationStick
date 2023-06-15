using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashObject : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;
    float _a_color;
    [Tooltip("ìßñæÇ©")] bool isTransparent;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        // èâä˙ÇÕïsìßñæ 
        _a_color = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // ìßñæÇ…Ç»Ç¡ÇΩÇÁ 
        if(_a_color <= 0)
        {
            isTransparent = true;
        }
        // ïsìßñæÇ…Ç»Ç¡ÇΩÇÁ 
        else if(_a_color >= 1)
        {
            isTransparent = false;
        }
        
        // ïsìßñæÇ…Ç∑ÇÈ 
        if(isTransparent)
        {
            _a_color += Time.deltaTime * 1.5f;
        }
        // ìßñæÇ…Ç∑ÇÈ 
        else if (! isTransparent)
        {
            _a_color -= Time.deltaTime * 1.5f;
        }

        _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, _a_color);
    }
}
