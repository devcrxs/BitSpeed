using UnityEngine;
public class SlowMotion : MonoBehaviour
{
    private float timeSlow = 0.02f;
    private float minTime = 0f;
    private float maxTime = 1f;
    public static SlowMotion instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Update()
    {
        TimeDefault();
    }

    private void TimeDefault()
    {
        Time.timeScale += 8 * Time.unscaledDeltaTime;
        GameManager.instance.ChangeTimeScale(Mathf.Clamp(Time.timeScale, minTime, maxTime));
    }

    public void Slow()
    {
        GameManager.instance.ChangeTimeScale(timeSlow);
        Time.fixedDeltaTime = timeSlow * Time.timeScale;
    }
}
