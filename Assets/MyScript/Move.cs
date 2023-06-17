using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; //TextMeshProを扱う際に必要
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    // 「start」がクリックされたらplayer追尾開始
    
    [Tooltip("「S」のクリック判定のフラグ")] bool _FlgBtn; 
    [Tooltip("playerの画像コンポーネント")] SpriteRenderer _sr;  
    Text _deathText;
    AudioSource _audioSource;
    [SerializeField, Tooltip("悲鳴")] AudioClip _audioClip;
    Collider2D _collider2D;
    [Tooltip("死んだ回数")] int _count = 0;

    void Start()
    {
        _count = 0;
        _audioSource = GetComponent<AudioSource>();

        _sr = GetComponent<SpriteRenderer>();
        _collider2D = GetComponent<Collider2D>();

        // 死んだ回数のテキスト参照
        GameObject deathTextObj = GameObject.Find("DeathText (Legacy)");
        _deathText = deathTextObj.GetComponent<Text>();
        
        OnChangeBoolToFalse();
    }

    void Update()
    {
        //countを文字列に変えてdTextに代入
        var dText = _count.ToString();

        //「Death」と「死んだ回数」を表示
        _deathText.text = "Death\n" + dText; 
        if (_FlgBtn == true)
        {
            //以下でカーソル追従
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
