using UnityEngine;
public class ColorLerp : MonoBehaviour
{
    private int colorIndex;
    private float timeChange;
    private float maxTimeChange = 0.9f;
    [SerializeField] [Range(0f, 1f)] private float lerpTime;
    [SerializeField] private Color[] colors;
    private Camera cameraLerp;

    private void Awake()
    {
        if (Camera.main != null) cameraLerp = Camera.main;
    }
    
    private void LateUpdate()
    {
        Lerp();
    }

    private void Lerp()
    {
        cameraLerp.backgroundColor = Color.Lerp(cameraLerp.backgroundColor,colors[colorIndex], lerpTime * Time.deltaTime);
        timeChange = Mathf.Lerp(timeChange, 1f, lerpTime * Time.deltaTime);
        ChangeColor();
    }

    private void ChangeColor()
    {
        if (timeChange > maxTimeChange)
        {
            timeChange = Constans.ZERO;
            colorIndex++;
            colorIndex = colorIndex >= colors.Length ? Constans.ZERO : colorIndex;
        }
    }
}
