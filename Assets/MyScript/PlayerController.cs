using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; //TextMeshPro�������ۂɕK�v
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // �ustart�v���N���b�N���ꂽ��player�ǔ��J�n

    [Tooltip("�uS�v�̃N���b�N����̃t���O")] bool _FlgBtn;
    [Tooltip("player�̉摜�R���|�[�l���g")] SpriteRenderer _sr;
    Text _deathText;
    AudioSource _audioSource;
    [SerializeField, Tooltip("�ߖ�")] AudioClip _audioClip;
    Collider2D _collider2D;
    [Tooltip("���񂾉�")] int _count = 0;
    [Tooltip("�ʒu�������܂ł̃J�E���g�_�E��")] Text _resetText;
    [SerializeField, Tooltip("�\�����镶��")] string _string;

    SlideController _slideController; 

    void Start()
    {
        _count = 0;
        _audioSource = GetComponent<AudioSource>();

        // ���񂾉񐔂̃e�L�X�g�Q��
        _deathText = GameObject.Find("DeathText (Legacy)").GetComponent<Text>();

        // �J�����ɘA�����ăX���C�h����I�u�W�F�N�g(�ʒu�������ɕK�v) 
        _slideController = GameObject.Find("SlideController").GetComponent<SlideController>(); 
        _resetText = GameObject.Find("DeathResetPosition").GetComponent<Text>();

        _sr = GetComponent<SpriteRenderer>();
        _collider2D = GetComponent<Collider2D>();

        OnChangeBoolToFalse();
    }

    void Update()
    {
        if (_FlgBtn == true)
        {
            //�ȉ��ŃJ�[�\���Ǐ]
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10.0f;
            transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        }

        //count�𕶎���ɕς���dText�ɑ��
        string dText = _count.ToString();
        //�uDeath�v�Ɓu���񂾉񐔁v��\��
        _deathText.text = "Death\n" + dText;

        // �uSlideController�v���C���X�y�N�^��ɂ���Ƃ� 
        if (_slideController != null)
        {
            // ��萔���񂾂��ƂɁA�����ʒu�֖߂� 
            // �u_count�v= 0 �̂Ƃ��Ɏ��s���Ȃ��悤�ɂ��� 
            // �����ƈʒu���������Ȃ��悤�ɂ��� 
            if (_count %  _slideController._resetTime == 0 && _count > 0 &&  _slideController._resetable == 0)
            {
                _slideController.ResetPosition();
            }
            // �Ăшʒu�������@�\���g����悤�� 
            if (_count % _slideController._resetTime == 1)
                _slideController._resetable = 0; 

        }
        // �uDeathResetPosition�v���C���X�y�N�^��ɂ���Ƃ� 
        if (_resetText != null)
        {
            string resetTime = _slideController._resetTime.ToString();
            _resetText.text = resetTime + _string;
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
