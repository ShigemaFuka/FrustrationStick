using UnityEngine;
using UnityEngine.SceneManagement; // UnityEngine.SceneManagemnt�̋@�\���g�p


public class GoalJudge : MonoBehaviour
{
    /// <summary>
    /// �v���C���[���S�[���ɐG�ꂽ��A�N���A�̃V�[���֑J�ڂ���
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //�����ŃV�[���؂�ւ�
            SceneManager.LoadScene("Goal");
            Debug.Log(other.gameObject.name + "��������");
        }
    }
}
