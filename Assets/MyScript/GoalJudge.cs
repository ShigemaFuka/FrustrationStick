using UnityEngine;
using UnityEngine.SceneManagement; // UnityEngine.SceneManagemnt�̋@�\���g�p


public class GoalJudge : MonoBehaviour
{
    private void Start()
    {
        //GameObject player = GameObject.FindWithTag("Player");
        //Debug.Log(player.name);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //�����ŃV�[���؂�ւ�
            SceneManager.LoadScene("Goal");

            Debug.Log(other.gameObject.name + "��������");
        }
    }
}
