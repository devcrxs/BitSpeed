using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerEffects : MonoBehaviour
{
    private float timeInstanceEcho = 0.1f;
    private float currentTimeEcho;
    private bool isGround;
    private bool isEffectGround;
    private void Update()
    {
        SmokeEffect();
        SmokeEffect();
        EchoEffect();
    }

    private void SmokeEffect()
    {
        if (isGround)
        {
            if (isEffectGround)
            {
                SoundsManager.instance.PlayTouchGround();
                EffectsManager.instance.PlaySmokeJump();
                isEffectGround = false;
            }
            return;
        }

        isEffectGround = true;
    }

    private void EchoEffect()
    {
        if (Input.touchCount > Constans.ZERO)
        {
            Touch touch = Input.GetTouch(Constans.ZERO);
            if (NotTouchingInterface(touch))
            {
                EffectsManager.instance.InstantiateEcho(transform.position);
                currentTimeEcho = timeInstanceEcho;
                return;
            }
            currentTimeEcho -= Time.deltaTime;
        }
    }

    private bool NotTouchingInterface(Touch touch)
    {
        return !EventSystem.current.IsPointerOverGameObject(touch.fingerId) && touch.phase != TouchPhase.Ended &&
               !GameManager.instance.isReset && !GameManager.instance.isWin && currentTimeEcho <= Constans.ZERO &&
               PlayerComponents.instance.Rb2D.velocity.x != 0;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (IsCollisionGround(other))
        {
            isGround = true;
            PlayerComponents.instance.Animator.SetBool(Constans.TAG_GROUND, true);
        }
    }
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (IsCollisionGround(other))
        {
            PlayerComponents.instance.Animator.SetBool(Constans.TAG_GROUND, true);
        }
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        if (IsCollisionGround(other))
        {
            isGround = false;
            PlayerComponents.instance.Animator.SetBool(Constans.TAG_GROUND, false);
        }
    }

    private bool IsCollisionGround(Collision2D other)
    {
        return other.gameObject.CompareTag(Constans.TAG_GROUND);
    }
}
