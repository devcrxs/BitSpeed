using UnityEngine;
public class Shooting : MonoBehaviour
{
    private float forceShoot = 45;
    private Transform pointShoot;
    private Camera cameraRipple;
    [SerializeField] private GameObject bulletPrefab;
    private void Awake()
    {
        cameraRipple = Camera.main;
    }

    private void Start()
    {
        pointShoot = GameObject.FindWithTag(PlayerConstants.TAG_POINT_SHOOT).transform;
    }

    public void Shoot()
    {
        if (AreThereBullets())
        {
            SoundsManager.instance.PlayShootSound();
            StartCoroutine(WeponRecoil.instance.Recoil());
            SlowMotion.instance.Slow();
            PlayerComponents.instance.Rb2D.velocity += KnockbackPlayer();
            Instantiate(bulletPrefab, pointShoot.position, Quaternion.identity);
            FindObjectOfType<RippleEffect>().Emit(cameraRipple.WorldToViewportPoint(transform.position));
            CameraShake.instance.Shake();
        }
    }

    private bool AreThereBullets()
    {
        return GameManager.instance.bullets > Constans.ZERO;
    }

    private Vector2 KnockbackPlayer()
    {
        var directionBullet = PlayerComponents.instance.PivotAim.right;
        return (Vector2) directionBullet *  -forceShoot;
    }
}
