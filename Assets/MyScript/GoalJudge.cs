using UnityEngine;
using UnityEngine.SceneManagement; // UnityEngine.SceneManagemntの機能を使用


public class GoalJudge : MonoBehaviour
{
    GameObject _player;
    Move _move;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _move = _player.GetComponent<Move>();
    }

    /// <summary>
    /// プレイヤーがゴールに触れたら、クリアのシーンへ遷移する
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _move.OnChangeBoolToFalse();
            //ここでシーン切り替え
            SceneManager.LoadScene("Goal");
        }
    }
}
