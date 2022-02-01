using UnityEngine;
public class PlayerDirectionSprite : MonoBehaviour
{
    private float maxEulerAngle = 360f;
    private float minEulerAngle = 90f;
    private float divEulerAngle = 270f;
    private Vector3 eulerAngles;
    
    private void Update()
    {
        CheckDirection();
    }

    private void CheckDirection()
    {
        PlayerComponents.instance.SpriteRenderer.flipX = IsFlipSprite();
    }

    private bool IsPositionLeft()
    {
        eulerAngles = PlayerComponents.instance.PivotAim.transform.eulerAngles;
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
