using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; //TextMeshPro�������ۂɕK�v
using UnityEngine.UI;
using Unity.VisualScripting;

public class Move : MonoBehaviour
{
    // �ustart�v���N���b�N���ꂽ��player�ǔ��J�n
    
    [Tooltip("�uS�v�̃N���b�N����̃t���O")] bool _FlgBtn; 
    [Tooltip("player�̉摜�R���|�[�l���g")] SpriteRenderer _sr;  
    Text _deathText;
    [Tooltip("�ڐG���ɍĐ�")] AudioSource _audioSource;
    [SerializeField, Tooltip("�ߖ�")] AudioClip _audioClip;
    [SerializeField, Tooltip("�N���b�N����obj")] GameObject _clickObjPrefab;
    CircleCollider2D _circleCollider2D;
    [Tooltip("���񂾉�")] int _count = 0;
    [Tooltip("Start�̈ʒu")] GameObject _startObj;

    void Start()
    {
        _FlgBtn = false;     //�܂��ǔ����Ȃ�

        //�uS�v���N���b�N�����܂ŉ摜���\���ɂ��Ă���
        _sr = GetComponent<SpriteRenderer>();
        _sr.enabled = false;

        _count = 0;

        // �ʒu�������� 
        _startObj = GameObject.Find("Start");
        transform.position = _startObj.transform.position;

        // ���񂾉񐔂̃e�L�X�g�Q��
        GameObject deathTextObj = GameObject.Find("DeathText (Legacy)");
        _deathText = deathTextObj.GetComponent<Text>();

        _audioSource = GetComponent<AudioSource>();

        _circleCollider2D = GetComponent<CircleCollider2D>();
        // �R���C�_OFF
        _circleCollider2D.enabled = false;
    }

    void Update()
    {
        //count����U������ɕς���dText�ɑ��
        var dText = _count.ToString();

        //�uDeath�v�Ɓu���񂾉񐔁v��\��
        _deathText.text = "Death\n" + dText; 
        if (_FlgBtn == true)
        {
            //�ȉ��ŃJ�[�\���Ǐ]
            var mousePosition = Input.mousePosition;
            //Debug.Log(mousePosition);
            mousePosition.z = 10.0f;
            transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Update()��if���̈ړ���~
        _FlgBtn = false;
        //�摜��\��
        _sr.enabled = false;
        // �R���C�_OFF
        _circleCollider2D.enabled = false;
        _count += 1;
        _audioSource.PlayOneShot(_audioClip);
        //_audioSource.Play();
        Debug.Log("���񂾉񐔁F"+_count);
        Debug.Log(collision.gameObject.name + "�ɓ���������");
    }

    //�uS�v���N���b�N���ꂽ����s
    public void OnClickStart()
    {
        //Update()��if���̈ړ��J�n
        _FlgBtn = true;
        //�摜�\��
        _sr.enabled = true;
        // �R���C�_ON
        _circleCollider2D.enabled = true;
    }
    
    // �����ł́uBack�v�{�^�����N���b�N���ꂽ��
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);

        OnChangeBoolToFalse();
    }

    public void OnChangeBoolToFalse()
    {
        //Update()��if���̈ړ��J�n
        _FlgBtn = false;
        //�摜�\��
        _sr.enabled = false;
        // �R���C�_ON
        _circleCollider2D.enabled = false;
    }
}
