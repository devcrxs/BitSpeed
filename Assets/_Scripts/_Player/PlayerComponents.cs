using UnityEngine;
public class PlayerComponents : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private SpriteRenderer spriteRenderer;
    private Transform pivotAim;
    private Animator animator;
    public static PlayerComponents instance;
    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        pivotAim = GameObject.FindWithTag(PlayerConstants.TAG_PIVOT_AIM).transform;
        animator = GetComponent<Animator>();
        if (instance == null) instance = this;
    }
    public Rigidbody2D Rb2D => rb2D;
    public SpriteRenderer SpriteRenderer => spriteRenderer;
    public Transform PivotAim => pivotAim;
    public Animator Animator => animator;
}
