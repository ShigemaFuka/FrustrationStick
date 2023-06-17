using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; //TextMeshPro�������ۂɕK�v
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    // �ustart�v���N���b�N���ꂽ��player�ǔ��J�n
    
    [Tooltip("�uS�v�̃N���b�N����̃t���O")] bool _FlgBtn; 
    [Tooltip("player�̉摜�R���|�[�l���g")] SpriteRenderer _sr;  
    Text _deathText;
    AudioSource _audioSource;
    [SerializeField, Tooltip("�ߖ�")] AudioClip _audioClip;
    Collider2D _collider2D;
    [Tooltip("���񂾉�")] int _count = 0;

    void Start()
    {
        _count = 0;
        _audioSource = GetComponent<AudioSource>();

        _sr = GetComponent<SpriteRenderer>();
        _collider2D = GetComponent<Collider2D>();

        // ���񂾉񐔂̃e�L�X�g�Q��
        GameObject deathTextObj = GameObject.Find("DeathText (Legacy)");
        _deathText = deathTextObj.GetComponent<Text>();
        
        OnChangeBoolToFalse();
    }

    void Update()
    {
        //count�𕶎���ɕς���dText�ɑ��
        var dText = _count.ToString();

        //�uDeath�v�Ɓu���񂾉񐔁v��\��
        _deathText.text = "Death\n" + dText; 
        if (_FlgBtn == true)
        {
            //�ȉ��ŃJ�[�\���Ǐ]
            var mousePosition = Input.mousePosition;
            mousePosition.z = 10.0f;
            transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        OnChangeBoolToFalse();
        _count ++;
        _audioSource.PlayOneShot(_audioClip);
    }

    //�uS�v���N���b�N���ꂽ����s
    public void OnClickStart()
    {
        //Update()��if���̈ړ��J�n
        _FlgBtn = true;
        //�摜�\��
        _sr.enabled = true;
        // �R���C�_ON
        _collider2D.enabled = true;
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
        //�摜��\��
        _sr.enabled = false;
        // �R���C�_OFF
        _collider2D.enabled = false;
    }
}
