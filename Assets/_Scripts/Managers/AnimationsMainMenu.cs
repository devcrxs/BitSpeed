using UnityEngine;
using UnityEngine.UI;
public class AnimationsMainMenu : AnimationsUI
{
    private float timeMove = 0.4f;
    private float timeScale = 0.3f;
    private float timeFade = 0.2f;
    private float fadeValue = 0.5f;
    private float positionMove = 800;
    private float defaultPosTextBit;
    private float defaultPosTextSpeed;
    private float defaultPosTextOptions;
    private float defaultPosTextDelet;
    private float defaultPosTextVolume;
    private float defaultPosButtonHistory;
    private float defaultPosButtonExit;
    private float defaultPosButtonOptions;
    private float defaultPosButtonDelet;
    private float defaultPosSlider;
    private float defaultPosButtonExitOptions;
    public static AnimationsMainMenu instance;
    [SerializeField] private Image backgroundPopDelet;
    [SerializeField] private Transform textBit;
    [SerializeField] private Transform textSpeed;
    [SerializeField] private Transform textOptions;
    [SerializeField] private Transform textDelet;
    [SerializeField] private Transform textVolume;
    [SerializeField] private Transform buttonHistory;
    [SerializeField] private Transform buttonExitGame;
    [SerializeField] private Transform buttonOptions;
    [SerializeField] private Transform buttonDelet;
    [SerializeField] private Transform sliderVolume;
    [SerializeField] private Transform buttonExitOptions;
    [SerializeField] private Transform canvasPopDelet;
    private void Awake()
    {
        if (instance == null) instance = this;
    }

    protected override void Start()
    {
        base.Start();
        GetInitialPosition();
        SetBackgroundPop(false,Constans.ZERO,Constans.ZERO,
            Vector3.zero,Constans.ZERO);
    }

    private void SetBackgroundPop(bool rayCastValue, float fadeValue, float durationFade, Vector3 scale, float durationScale)
    {
        backgroundPopDelet.raycastTarget = rayCastValue;
        DoFade(backgroundPopDelet,fadeValue,durationFade);
        DoScale(canvasPopDelet,scale,durationScale);
    }
    private void GetInitialPosition()
    {
        defaultPosTextBit = textBit.localPosition.x;
        defaultPosTextSpeed = textSpeed.localPosition.x;
        defaultPosTextOptions = textOptions.localPosition.x;
        defaultPosTextDelet = textDelet.localPosition.x;
        defaultPosTextVolume = textVolume.localPosition.x;
        defaultPosButtonHistory = buttonHistory.localPosition.x;
        defaultPosButtonExit = buttonExitGame.localPosition.x;
        defaultPosButtonOptions = buttonOptions.localPosition.x;
        defaultPosButtonDelet = buttonDelet.localPosition.x;
        defaultPosSlider = sliderVolume.localPosition.x;
        defaultPosButtonExitOptions = buttonExitOptions.localPosition.x;
        HideOptionsGameObjects(Constans.ZERO);
    }
    
    public void ActiveOptions()
    {
        DoMoveX(textBit,-positionMove,timeMove);
        DoMoveX(textSpeed,positionMove,timeMove);
        DoMoveX(buttonHistory,-positionMove,timeMove);
        DoMoveX(buttonExitGame,-positionMove, timeMove);
        DoMoveX(buttonOptions,positionMove, timeMove);
        ShowOptionsGameObjects();
    }

    public void DesactiveOptions()
    {
        HideOptionsGameObjects(timeMove);
        DoMoveX(textBit,defaultPosTextBit,timeMove);
        DoMoveX(textSpeed,defaultPosTextSpeed,timeMove);
        DoMoveX(buttonHistory,defaultPosButtonHistory,timeMove);
        DoMoveX(buttonExitGame,defaultPosButtonExit, timeMove);
        DoMoveX(buttonOptions,defaultPosButtonOptions, timeMove);
    }

    private void HideOptionsGameObjects(float timeMoveX)
    {
        DoMoveX(textOptions,-positionMove,timeMoveX);
        DoMoveX(textDelet,positionMove,timeMoveX);
        DoMoveX(textVolume,-positionMove,timeMoveX);
        DoMoveX(buttonDelet,-positionMove,timeMoveX);
        DoMoveX(sliderVolume,positionMove,timeMoveX);
        DoMoveX(buttonExitOptions,positionMove,timeMoveX);
    }

    private void ShowOptionsGameObjects()
    {
        DoMoveX(textOptions,defaultPosTextOptions,timeMove);
        DoMoveX(textDelet,defaultPosTextDelet,timeMove);
        DoMoveX(textVolume,defaultPosTextVolume,timeMove);
        DoMoveX(buttonDelet,defaultPosButtonDelet,timeMove);
        DoMoveX(sliderVolume,defaultPosSlider,timeMove);
        DoMoveX(buttonExitOptions,defaultPosButtonExitOptions,timeMove);
    }
    
    public void ShowPopDelet()
    {
        SetBackgroundPop(true,fadeValue,timeFade,Vector3.one,timeScale);
    }

    public void HidePopDelet()
    {
        SetBackgroundPop(false,Constans.ZERO,timeFade,Vector3.zero,timeScale);
    }
}
