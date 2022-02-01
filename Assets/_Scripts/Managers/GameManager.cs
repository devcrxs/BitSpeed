using System.Collections;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public bool isReset;
    public bool isWin;
    public float bullets;
    private float saveBullets;
    private float timeScaleDefault = 1;
    private float waitSecondsReset = 0.7f;
    public static GameManager instance;
    private Vector2 savePositionPlayerStart;
    private GameObject[] destroyObjects;
    [SerializeField]private GameObject playerGameObject;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        destroyObjects =  GameObject.FindGameObjectsWithTag(Constans.TAG_DESTROYABLE_OBJECT);
        savePositionPlayerStart = PlayerComponents.instance.transform.position;
        saveBullets = bullets;
    }

    private void Update()
    {
        CheckActualBullets();
    }

    private void CheckActualBullets()
    {
        if (IsGameOver())
        {
            StartCoroutine(WaitResetPlayer());
        }
    }

    private bool IsGameOver()
    {
        return bullets < Constans.ZERO && !isReset;
    }
    public IEnumerator WaitResetPlayer()
    {
        isReset = true;
        bullets = saveBullets;
        SoundsManager.instance.PlayHurtSound();
        PlayerPrefs.SetInt(KeysPlayerPrefs.KEY_ACTUAL_KILLS,PlayerPrefs.GetInt(KeysPlayerPrefs.KEY_ACTUAL_KILLS) + 1);
        ChangeTimeScale(timeScaleDefault);
        PlayerComponents.instance.Rb2D.velocity = Vector2.zero;
        playerGameObject.SetActive(false);
        EffectsManager.instance.InstantiateWaveEffect(playerGameObject.transform.position);
        PlayerComponents.instance.transform.position = savePositionPlayerStart;
        yield return new WaitForSeconds(waitSecondsReset);
        UIManager.instance.ResetBullets();
        ResetDestroyableObjects();
        PlayerComponents.instance.SpriteRenderer.flipX = false;
        playerGameObject.SetActive(true);
        isReset = false;
    }

    private void ResetDestroyableObjects()
    {
        if (destroyObjects == null) return;
        foreach (var destroyable in destroyObjects)
        {
            destroyable.SetActive(true);
        }
    }

    public  void WinLevel(string nameNextScene)
    {
        isWin = true;
        UIManager.instance.ChangeScene(nameNextScene);
    }

    public void ChangeTimeScale(float timeScaleValue)
    {
        Time.timeScale = timeScaleValue;
    }
}
