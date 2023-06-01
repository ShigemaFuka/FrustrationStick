using UnityEngine;
using UnityEngine.SceneManagement; // UnityEngine.SceneManagemntの機能を使用


public class GoalJudge : MonoBehaviour
{
    /// <summary>
    /// プレイヤーがゴールに触れたら、クリアのシーンへ遷移する
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //ここでシーン切り替え
            SceneManager.LoadScene("Goal");
            Debug.Log(other.gameObject.name + "着いたよ");
        }
    }
}
