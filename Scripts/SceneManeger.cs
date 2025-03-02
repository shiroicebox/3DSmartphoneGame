using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManeger : MonoBehaviour
{
    public FadeSceneLoader fadeSceneLoader;
    private void Start()
    {
        // ¶Œü‚«‚ğ—LŒø‚É‚·‚é
        Screen.autorotateToLandscapeLeft = true;
        // ‰EŒü‚«‚ğ—LŒø‚É‚·‚é
        Screen.autorotateToLandscapeRight = true;

        // ‰æ–Ê‚ÌŒü‚«‚ğ©“®‰ñ“]‚Éİ’è‚·‚é
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
