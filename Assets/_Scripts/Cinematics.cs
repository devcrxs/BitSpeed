using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Cinematics : AnimationsUI
{
    private bool isSkip;
    private float waitSecondsTransition = 0.6f;
    private float fadeBackgroundValue = 0.5f;
    private float timeFade = 0.2f;
    private float timeMove = 0.4f;
    private float timeScale = 0.3f;
    private Vector2 defaultPosition = new Vector2(350, 175);
    [SerializeField] private string nameScene;
    [SerializeField] private float waitCinmeatic;
    [SerializeField] private Image imageBackgroundPop;
    [SerializeField] private Transform canvasPop;
    [SerializeField] private Animator animatorTransition;
    protected override void Start()
    {
        base.Start();
        SetBackgroundPop(false,Constans.ZERO,Constans.ZERO, 
            Vector3.zero,Constans.ZERO,defaultPosition,Constans.ZERO);
        StartCoroutine(WaitChangeSceneCinematic());
    }

    private void SetBackgroundPop(bool rayCastValue, float fadeValue, float durationFade, 
        Vector3 scale, float durationScale, Vector3 position, float durationMove)
    {
        imageBackgroundPop.raycastTarget = rayCastValue;
        DoFade(imageBackgroundPop,fadeValue,durationFade);
        DoScale(canvasPop,scale,durationScale);
        DoMove(canvasPop,position,durationMove);
    }
    private IEnumerator WaitChangeSceneCinematic()
    {
        yield return new WaitForSeconds(waitCinmeatic);
        StartCoroutine(ChangeScene());
    }

    private IEnumerator ChangeScene()
    {
        animatorTransition.Play(Constans.OUT);
        yield return new WaitForSeconds(waitSecondsTransition);
        SceneManager.LoadSceneAsync(nameScene);
    }

    public void ShowPop()
    {
        SoundsManager.instance.PlayUISound();
        SetBackgroundPop(true,fadeBackgroundValue,timeFade,
            Vector3.one,timeScale,Vector3.zero,timeMove);

    }

    public void HidePop()
    {
        SoundsManager.instance.PlayUISound();
        SetBackgroundPop(false,Constans.ZERO,timeFade,
            Vector3.zero, timeScale,defaultPosition,timeMove);

    }
    public void SkipCinematic()
    {
        if (isSkip) return;
        isSkip = true;
        SoundsManager.instance.PlayUISound();
        StartCoroutine(ChangeScene());
    }
}
