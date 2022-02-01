using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : AnimationsUI
{
    private int maxBullets;
    private float timeMove = 0.4f;
    private float timeFade = 0.2f;
    private float fadeValue = 0.5f;
    private float positionMove = 800;
    private float defaultPosTextPause;
    private float defaultPosTextKills;
    private float defaultPosButtonReturn;
    private float defaultPosButtonMenu;
    private float waitSecondsChangeScene = 0.6f;
    public static UIManager instance;
    [SerializeField] private Image backgroundPause;
    [SerializeField] private Transform textPause;
    [SerializeField] private Transform textKills;
    [SerializeField] private Transform buttonReturn;
    [SerializeField] private Transform buttonMenu;
    [SerializeField] private SpriteRenderer bulletDesactive;
    [SerializeField] private SpriteRenderer defaultBulletSprite;
    [SerializeField] private Animator animatorTransition;
    [SerializeField] private GameObject[] buttonsUI;
    [SerializeField] private Image[] bulletsActive;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    protected override void Start()
    {
        base.Start();
        SetBackground(false,Constans.ZERO,Constans.ZERO);
        GetIntialPosition();
        HidePauseGameObjects(Constans.ZERO);
        maxBullets = bulletsActive.Length -1;
    }

    private void SetBackground(bool rayCastValue, float fadeValue, float duration)
    {
        backgroundPause.raycastTarget = rayCastValue;
        DoFade(backgroundPause,fadeValue,duration);
    }

    private void GetIntialPosition()
    {
        defaultPosTextPause = textPause.localPosition.x;
        defaultPosTextKills = textKills.localPosition.x;
        defaultPosButtonReturn = buttonReturn.localPosition.x;
        defaultPosButtonMenu = buttonMenu.localPosition.x;
    }

    private void HidePauseGameObjects(float timeMove)
    {
        SetBackground(false,Constans.ZERO,timeFade);
        DoMoveX(textPause,positionMove,timeMove);
        DoMoveX(textKills,-positionMove,timeMove);
        DoMoveX(buttonReturn,-positionMove,timeMove);
        DoMoveX(buttonMenu,positionMove,timeMove);
    }

    private void ShowPauseGameObjects()
    {
        textKills.GetComponent<Text>().text = PlayerPrefs.GetInt(KeysPlayerPrefs.KEY_ACTUAL_KILLS, Constans.ZERO).ToString();
        SetBackground(true,fadeValue,timeFade);
        DoMoveX(textPause,defaultPosTextPause,timeMove);
        DoMoveX(textKills,defaultPosTextKills,timeMove);
        DoMoveX(buttonReturn,defaultPosButtonReturn,timeMove);
        DoMoveX(buttonMenu,defaultPosButtonMenu, timeMove);
    }

    public void BulletsCount()
    {
        bulletsActive[maxBullets].sprite = bulletDesactive.sprite;
        if (maxBullets > Constans.ZERO)
        {
            maxBullets--;
        }
    }

    public void ResetBullets()
    {
        foreach (var bullet in bulletsActive)
        {
            bullet.sprite = defaultBulletSprite.sprite;
        }
        maxBullets = bulletsActive.Length -1;
    }

    public void ResetLevel()
    { 
        SoundsManager.instance.PlayUISound();
        StartCoroutine(GameManager.instance.WaitResetPlayer());
    }

    public void Pause()
    {
        SoundsManager.instance.PlayUISound();
        foreach (var button in buttonsUI) button.SetActive(false);
        ShowPauseGameObjects();
    }

    public void ReturnGame()
    {
        SoundsManager.instance.PlayUISound();
        foreach (var button in buttonsUI) button.SetActive(true);
        HidePauseGameObjects(timeMove);
    }

    public void ChangeScene(string nameScene)
    {
        StartCoroutine(WaitChangeScene(nameScene));
    }

    private IEnumerator WaitChangeScene(string nameScene)
    {
        animatorTransition.Play(Constans.OUT);
        yield return new WaitForSeconds(waitSecondsChangeScene);
        SceneManager.LoadSceneAsync(nameScene);
    }
}
