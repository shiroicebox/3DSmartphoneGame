using Cinemachine;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class ResultManeger : MonoBehaviour
{

    [Header("Game Result Maneger")]
    [SerializeField] private TimeManeger _timeManeger;
    [SerializeField] private CameraManeger _cameraManeger;
    [SerializeField] private ThirdPersonController _Player;

    public GameObject _resultPanel;         // ���U���g���

    public TextMeshProUGUI _textGameClear;  // �Q�[���N���A�̃e�L�X�g
    public TextMeshProUGUI _textGameOver;  // �Q�[���I�[�o�[�̃e�L�X�g

    // Start is called before the first frame update
    void Start()
    {
        _textGameClear.text = "";
        _textGameOver.text = "";
        _resultPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // �B�e�Ώۂ��B�e�ł�����N���A
        if (_cameraManeger._isClear)
        {
            GameClear();
            return;
        }

        // �c��t�B������0�������͎��Ԑ؂�ŃQ�[���I�[�o�[
        // �Q�[���̃N���A���肪��Ȃ̂ŃN���A��ԂłȂ��Ńt�B������0�Ȃ�Q�[���I�[�o�[
        if (_cameraManeger._restFilm == 0 || _timeManeger._isTimeUp || _Player._isEnemyAtack)
        {
            GameOver();
            return;
        }

    }

    public void GameClear()
    {
        Debug.Log("�Q�[���N���A");
        _resultPanel.SetActive(true);
        _textGameClear.text = "Game Clear";
        _textGameClear.color = Color.green;
    }

    public void GameOver()
    {
        Debug.Log("�Q�[���I�[�o�[");
        _resultPanel.SetActive(true);
        _textGameOver.text = "Game Over";
        _textGameOver.color = Color.red;
    }

    public void PausePanel()
    {
        _resultPanel.SetActive(true);
    }

    public void BackButton()
    {
        _resultPanel.SetActive(false);
    }
}
