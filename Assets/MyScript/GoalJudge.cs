using UnityEngine;
using UnityEngine.SceneManagement; // UnityEngine.SceneManagemnt�̋@�\���g�p


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
    /// �v���C���[���S�[���ɐG�ꂽ��A�N���A�̃V�[���֑J�ڂ���
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _move.OnChangeBoolToFalse();
            //�����ŃV�[���؂�ւ�
            SceneManager.LoadScene("Goal");
        }
    }
}
