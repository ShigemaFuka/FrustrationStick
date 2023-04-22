using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GimmickMoveStraight : MonoBehaviour
{
    // 一方向のみに自動で動くギミック
    public float speed = 5.0f;
    public bool flag;
    public float x_value;
    public float y_range;

    private void Start()
    {
        Debug.Log(this.gameObject.name+"(x, y, z) = " + transform.position);
        Debug.Log("x = " + transform.position.x);
        Debug.Log("y = " + transform.position.y);
        Debug.Log("z = " + transform.position.z);
        x_value = transform.position.x;
    }

    void Update()
    {
        //これをアタッチしてるオブジェクトが「水平移動」のタグが付いていたら実行
        if(this.gameObject.CompareTag("HorizontalMovement"))
        {
            // フラグを操作
            if (transform.position.y >= y_range)
                flag = true;
            else if (transform.position.y <= -y_range)
                flag = false;

            //以下フラグによって実行内容を分けている
            if (flag)
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(x_value, -y_range, 0), speed * Time.deltaTime);
            else if (!flag)
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(x_value, y_range, 0), speed * Time.deltaTime);
        }
        /*
        else if(this.gameObject.CompareTag("VerticalMovement"))
        {

        }*/


    }
}
