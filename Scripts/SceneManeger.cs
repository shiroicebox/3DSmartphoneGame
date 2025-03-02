using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManeger : MonoBehaviour
{
    public FadeSceneLoader fadeSceneLoader;
    private void Start()
    {
        // ��������L���ɂ���
        Screen.autorotateToLandscapeLeft = true;
        // �E������L���ɂ���
        Screen.autorotateToLandscapeRight = true;

        // ��ʂ̌�����������]�ɐݒ肷��
        Screen.orientation = ScreenOrientation.AutoRotation;
    }

    public void MoveScene_Title()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void MoveScene_StageSelect()
    {
        fadeSceneLoader.sceneTitle = "StageSelectScene";
        fadeSceneLoader.CallCoroutine();
    }

    public void MoveScene_Main()
    {
        fadeSceneLoader.sceneTitle = "MainScene";
        fadeSceneLoader.CallCoroutine();
    }

}
