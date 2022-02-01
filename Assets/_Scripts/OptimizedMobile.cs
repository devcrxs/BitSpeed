using UnityEngine;
public class OptimizedMobile : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 60;
        Screen.SetResolution(Screen.width, Screen.height, true);
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
}
