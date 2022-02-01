using UnityEngine;
public class EffectsManager : MonoBehaviour
{
    private float timeDestroyEcho = 2f;
    public static EffectsManager instance;

    [Header("Prefabs")]
    [SerializeField] private GameObject clickEffect;
    [SerializeField] private GameObject explosionSmokeEffect;
    [SerializeField] private GameObject echoEffectLeft;
    [SerializeField] private GameObject echoEffectRight;
    [SerializeField] private GameObject waveEffect;
    [SerializeField] private GameObject colorWall;
    [SerializeField] private GameObject destroyBlock;
    [SerializeField] private GameObject contractEffect;
    [SerializeField] private GameObject destroyableObjectEffect;
    
    [Header("ParticleSystem")]
    [SerializeField] private ParticleSystem flashEffect;
    [SerializeField] private ParticleSystem smokeJump;
    
    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void InstantiateClickEffect(Vector2 position,  Quaternion rot)
    {
        Instantiate(clickEffect, position, rot);
    }
    
    public void InstantiateEcho(Vector2 position)
    {
        GameObject echoGameObject;
        if (IsFlipPlayer())
        {
            echoGameObject =  Instantiate(echoEffectRight, position, Quaternion.identity);
            Destroy(echoGameObject, timeDestroyEcho);
            return;
        }
        echoGameObject =  Instantiate(echoEffectLeft, position, Quaternion.identity);
        Destroy(echoGameObject, timeDestroyEcho);
    }

    private bool IsFlipPlayer()
    {
        return PlayerComponents.instance.SpriteRenderer.flipX;
    }
    public void InstantiateExplosionSmoke(Vector2 position)
    {
        Instantiate(explosionSmokeEffect, position,Quaternion.identity);
    }

    public void InstantiateColorWall(Vector2 position)
    {
        Instantiate(colorWall, position, Quaternion.identity);
    }
    
    public void InstantiateWaveEffect(Vector2 position)
    {
        Instantiate(waveEffect, position, Quaternion.identity);
    }

    public void InstantiateDestroyBlock(Vector2 position)
    {
        Instantiate(destroyBlock, position, Quaternion.identity);
    }

    public void InstantiateContract(Vector2 position)
    {
        Instantiate(contractEffect, position, Quaternion.identity);
    }

    public void InstantiateDestroyableObject(Vector2 position)
    {
        Instantiate(destroyableObjectEffect, position, Quaternion.identity);
    }
    public void PlayFlash()
    {
        flashEffect.Play();
    }

    public void PlaySmokeJump()
    {
        smokeJump.Play();
    }
}
