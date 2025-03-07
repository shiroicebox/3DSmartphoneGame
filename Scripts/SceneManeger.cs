using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManeger : MonoBehaviour
{
    public FadeSceneLoader fadeSceneLoader;
    private void Start()
    {
        // 左向きを有効にする
        Screen.autorotateToLandscapeLeft = true;
        // 右向きを有効にする
        Screen.autorotateToLandscapeRight = true;

        // 画面の向きを自動回転に設定する
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
