using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    private float waitSecondsChangeScene = 0.6f;
    [SerializeField] private Animator animatorTransition;

    public void ActiveOptions()
    {
        AnimationsMainMenu.instance.ActiveOptions();
    }

    public void DesactiveOptions()
    {
        AnimationsMainMenu.instance.DesactiveOptions();
    }

    public void GoModeHistory()
    {
        if(PlayerPrefs.GetString(KeysPlayerPrefs.KEY_LEVEL_SAVE, Constans.SCENE_LEVEL_0) != Constans.SCENE_LEVEL_0) ChangeBackgroundMusic.instance.BackgroundLevel();
        StartCoroutine(WaitChangeScene(PlayerPrefs.GetString(KeysPlayerPrefs.KEY_LEVEL_SAVE, Constans.SCENE_LEVEL_0)));
    }

    private IEnumerator WaitChangeScene(string nameScene)
    {
        animatorTransition.Play(Constans.OUT);
        yield return new WaitForSeconds(waitSecondsChangeScene);
        SceneManager.LoadSceneAsync(nameScene);
    }

    public void ShowPopDelet()
    {
        AnimationsMainMenu.instance.ShowPopDelet();
    }

    public void HidePopDelet()
    {
        AnimationsMainMenu.instance.HidePopDelet();
    }

    public void DeletModeHistory()
    {
        PlayerPrefs.DeleteKey(KeysPlayerPrefs.KEY_LEVEL_SAVE);
        PlayerPrefs.DeleteKey(KeysPlayerPrefs.KEY_TUTORIAL_HISTORY);
        PlayerPrefs.DeleteKey(KeysPlayerPrefs.KEY_ACTUAL_KILLS);
        HidePopDelet();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
