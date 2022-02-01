using UnityEngine;
public class WeponDirectionSprite : MonoBehaviour
{
    private float maxEulerAngle = 360f;
    private float minEulerAngle = 90f;
    private float divEulerAngle = 270f;
    private Vector3 eulerAngles;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        CheckDirection();
    }

    private void CheckDirection()
    {
        spriteRenderer.flipY = IsFlipSprite();
    }

    private bool IsPositionLeft()
    {
        eulerAngles = transform.eulerAngles;
        return (eulerAngles.z <= maxEulerAngle &&
                eulerAngles.z > divEulerAngle) || eulerAngles.z < minEulerAngle;
    }
    private bool IsFlipSprite()
    {
        if (IsPositionLeft())
        {
            return false;
        }
        return true;
    }
}
