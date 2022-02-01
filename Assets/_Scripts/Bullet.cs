using UnityEngine;
public class Bullet : MonoBehaviour
{
    private float speed = 30;
    private float timeCurrent;
    private float maxTime = 0.6f;
    private Transform directionBullet;
    private Rigidbody2D rb2D;

    private void Start()
    {
        timeCurrent = maxTime;
        rb2D = GetComponent<Rigidbody2D>();
        directionBullet = GameObject.FindWithTag(PlayerConstants.TAG_POINT_SHOOT).transform;
        rb2D.AddForce(ForceBullet(),ForceMode2D.Impulse);
    }

    private Vector2 ForceBullet()
    {
        return speed * directionBullet.right;
    }

    private void Update()
    {
        LifeBullet();
    }

    private void LifeBullet()
    {
        if (timeCurrent <= Constans.ZERO)
        {
            EffectsManager.instance.InstantiateExplosionSmoke(transform.position);
            Destroy(gameObject);
            return;
        }
        timeCurrent -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsHitTheEnviroment(other))
        {
            var instancePosition = transform.position;
            EffectsManager.instance.InstantiateDestroyBlock(instancePosition);
            EffectsManager.instance.InstantiateColorWall(instancePosition);
            EffectsManager.instance.InstantiateExplosionSmoke(instancePosition);
            Destroy(gameObject);
        }
    }

    public bool IsHitTheEnviroment(Collider2D other)
    {
        return other.CompareTag(Constans.TAG_ENVIROMENT) || other.CompareTag(Constans.TAG_GROUND) ||
               other.CompareTag(Constans.TAG_DESTROYABLE_OBJECT);
    }
}
