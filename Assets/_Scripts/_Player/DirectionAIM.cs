using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
public class DirectionAIM : MonoBehaviour
{
    private Shooting shooting;

    private void Start()
    {
        shooting = GameObject.FindWithTag(PlayerConstants.TAG_PLAYER).GetComponent<Shooting>();
    }

    void LateUpdate()
    {
        AngleAim();
    }

    private void AngleAim()
    {
        if (IsTouchScreen())
        {
            DirectionWepon();
        }

        transform.rotation = transform.rotation;
    }

    private bool IsTouchScreen()
    {
        return Input.touchCount > Constans.ZERO;
    }
    private void DirectionWepon()
    {
        Touch touch = Input.GetTouch(Constans.ZERO);
        if (NotTouchingInterface(touch))
        {
            if (touch.phase == TouchPhase.Began)
            {
                var posTouch = Camera.main.ScreenToWorldPoint(touch.position) - transform.position;
                var angle = Mathf.Atan2(posTouch.y, posTouch.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                
                //Shoot
                Shoot();
                
                //Efects
                Effects(touch);

                //UI
                UI();
            }
        }
    }

    private bool NotTouchingInterface(Touch touch)
    {
        return !EventSystem.current.IsPointerOverGameObject(touch.fingerId) && touch.phase != TouchPhase.Ended &&
               !GameManager.instance.isReset && !GameManager.instance.isWin;
    }

    private void Shoot()
    {
        shooting.Shoot();
        GameManager.instance.bullets--;
    }

    private void Effects(Touch touch)
    {
        EffectsManager.instance.InstantiateClickEffect(Camera.main.ScreenToWorldPoint(touch.position),quaternion.identity);
        EffectsManager.instance.PlayFlash();
    }

    private void UI()
    {
        UIManager.instance.BulletsCount();
    }
}
