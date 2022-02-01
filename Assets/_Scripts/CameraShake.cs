using UnityEngine;
public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;
    private Animator animator;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Shake()
    {
        animator.Play(Constans.SHAKE,Constans.ZERO);
    }
}
