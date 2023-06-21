using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; //TextMeshProを扱う際に必要
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // 「start」がクリックされたらplayer追尾開始

    [Tooltip("「S」のクリック判定のフラグ")] bool _FlgBtn;
    [Tooltip("playerの画像コンポーネント")] SpriteRenderer _sr;
    Text _deathText;
    AudioSource _audioSource;
    [SerializeField, Tooltip("悲鳴")] AudioClip _audioClip;
    Collider2D _collider2D;
    [Tooltip("死んだ回数")] int _count = 0;
    [Tooltip("位置初期化までのカウントダウン")] Text _resetText;
    [SerializeField, Tooltip("表示する文字")] string _string;

    SlideController _slideController; 

    void Start()
    {
        _count = 0;
        _audioSource = GetComponent<AudioSource>();

        // 死んだ回数のテキスト参照
        _deathText = GameObject.Find("DeathText (Legacy)").GetComponent<Text>();

        // カメラに連動してスライドするオブジェクト(位置初期化に必要) 
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
            //以下でカーソル追従
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10.0f;
            transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        }

        //countを文字列に変えてdTextに代入
        string dText = _count.ToString();
        //「Death」と「死んだ回数」を表示
        _deathText.text = "Death\n" + dText;

        // 「SlideController」がインスペクタ上にあるとき 
        if (_slideController != null)
        {
            // 一定数死んだごとに、初期位置へ戻る 
            // 「_count」= 0 のときに実行しないようにした 
            // ずっと位置初期化しないようにした 
            if (_count %  _slideController._resetTime == 0 && _count > 0 &&  _slideController._resetable == 0)
            {
                _slideController.ResetPosition();
            }
            // 再び位置初期化機能を使えるように 
            if (_count % _slideController._resetTime == 1)
                _slideController._resetable = 0; 

        }
        // 「DeathResetPosition」がインスペクタ上にあるとき 
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

    //「S」をクリックされたら実行
    public void OnClickStart()
    {
        //Update()のif文の移動開始
        _FlgBtn = true;
        //画像表示
        _sr.enabled = true;
        // コライダON
        _collider2D.enabled = true;
    }
    
    // ここでは「Back」ボタンがクリックされたら
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);

        OnChangeBoolToFalse();
    }

    public void OnChangeBoolToFalse()
    {
        //Update()のif文の移動開始
        _FlgBtn = false;
        //画像非表示
        _sr.enabled = false;
        // コライダOFF
        _collider2D.enabled = false;
    }
}
