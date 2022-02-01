using System.Collections;
using UnityEngine;
public class WeponRecoil : MonoBehaviour
{
    private float waitSecondsRecoil = 0.3f;
    private  float multiplyRecoil = 1f;
    private  float recoilAdjustment = 2;
    public static WeponRecoil instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public  IEnumerator Recoil()
    {
        waitSecondsRecoil = 0.5f / recoilAdjustment;
        var lerpPosition = Vector2.Lerp(transform.localPosition, transform.right * -multiplyRecoil, 0.1f);
        transform.localPosition = lerpPosition;
        yield return new WaitForSeconds(waitSecondsRecoil);
        transform.localPosition = Vector2.zero;
    }
}
