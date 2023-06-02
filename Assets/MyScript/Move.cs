using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; //TextMeshPro�������ۂɕK�v
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    // �ustart�v���N���b�N���ꂽ��player�ǔ��J�n
    
    public bool FlgBtn;         //�uS�v�̃N���b�N����̃t���O
    public SpriteRenderer sr;   //player�̉摜�R���|�[�l���g
    [SerializeField] //TextMeshProUGUI deathText;
    Text deathText;

    void Start()
    {
        FlgBtn = false;     //�܂��ǔ����Ȃ�
        //�uS�v���N���b�N�����܂ŉ摜���\���ɂ��Ă���
        sr.enabled = false;
        count = 0;
        GameObject startObj = GameObject.Find("Start");
        transform.position = startObj.transform.position;
    }

    void Update()
    {
        //count����U������ɕς���dText�ɑ��
        var dText = count.ToString();

        //�uDeath�v�Ɓu���񂾉񐔁v��\��
        deathText.text = "Death\n" + dText;
        if (FlgBtn == true)
        {
            //�ȉ��ŃJ�[�\���Ǐ]
            var mousePosition = Input.mousePosition;
            //Debug.Log(mousePosition);
            mousePosition.z = 10.0f;
            transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        }
    }

    int count = 0;
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Update()��if���̈ړ���~
        FlgBtn = false;
        //�摜��\��
        sr.enabled = false;
        count += 1;
        Debug.Log("���񂾉񐔁F"+count);
        Debug.Log(collision.gameObject.name + "�ɓ���������");
    }

    //�uS�v���N���b�N���ꂽ����s
    public void OnClickStart()
    {
        //Update()��if���̈ړ��J�n
        FlgBtn = true;
        //�摜�\��
        sr.enabled = true;
    }
    
    //�uBack�v�{�^�����N���b�N���ꂽ��
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
        Debug.Log("ChangeScene!!");
    }



}
