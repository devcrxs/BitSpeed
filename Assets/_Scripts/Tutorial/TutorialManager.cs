using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TutorialManager : MonoBehaviour
{
    private float timeShowCharacter = 0.03f;
    private bool isShowLettering;
    private Animator animatorTutorial;
    private Queue<string> queueDialogues;
    public TextDialogues textDialogues;
    [SerializeField] private Image imageRaycastText;
    [SerializeField] private Text textScreen;
    [SerializeField] private GameObject touchManager;
    [SerializeField] private GameObject bulletsTutorial;
    [SerializeField] private Image imagePlayer;
    [SerializeField] private GameObject[] desactiveObjectsTutorial;
    [SerializeField] private Sprite[] facesPlayer;

    private void Start()
    {
        animatorTutorial = GetComponent<Animator>();
        Tutorial();
    }

    private void Tutorial()
    {
        if (TheTutorialHasNotBeenShowm())
        {
            queueDialogues = new Queue<string>(textDialogues.arrayText.Length);
            bulletsTutorial.SetActive(false);
            UserInterfacesObjects(false);
            ActiveText();
            return;
        }
        gameObject.SetActive(false);
    }

    private bool TheTutorialHasNotBeenShowm()
    {
        return PlayerPrefs.GetInt(KeysPlayerPrefs.KEY_TUTORIAL_HISTORY, Constans.ZERO) <= Constans.ZERO;
    }

    private void UserInterfacesObjects(bool value)
    {
        foreach (var go in desactiveObjectsTutorial) go.SetActive(value);
    }

    private void ActiveText()
    {
        queueDialogues.Clear();
        foreach (var textShow in textDialogues.arrayText) queueDialogues.Enqueue(textShow);
        NextText();
    }

    public void NextText()
    {
        if (IsFinishTutorial())
        {
            SoundsManager.instance.StopTextSound();
            animatorTutorial.Play(Constans.RUN);
            imageRaycastText.raycastTarget = false;
            UserInterfacesObjects(true);
            PlayerPrefs.SetInt(KeysPlayerPrefs.KEY_TUTORIAL_HISTORY,1);
            return;
        }
        if(!isShowLettering)
        {
            isShowLettering = true;
            SoundsManager.instance.PlayInteractionSound();
            string actualText = queueDialogues.Dequeue();
            StartCoroutine(ShowCharacterText(actualText));
        }
    }

    private bool IsFinishTutorial()
    {
        return queueDialogues.Count == Constans.ZERO;
    }

    private IEnumerator ShowCharacterText(string show)
    {
        textScreen.text = "";
        SoundsManager.instance.PlayTextSound();
        foreach (var character in show.ToCharArray())
        {
            touchManager.SetActive(false);
            textScreen.text += character;
            yield return new WaitForSeconds(timeShowCharacter);
            ShowBullets();
        }
        isShowLettering = FinishParagraph();
    }

    private void ShowBullets()
    {
        if (queueDialogues.Count == 2)
        {
            bulletsTutorial.SetActive(true);
        }
    }

    private bool FinishParagraph()
    {
        imagePlayer.sprite = facesPlayer[Random.Range(Constans.ZERO, facesPlayer.Length)];
        touchManager.SetActive(true);
        SoundsManager.instance.StopTextSound();
        return false;
    }

    public void DesactiveTutorial() // Se usa como evento de animacion
    {
        gameObject.SetActive(false);
    }
}
