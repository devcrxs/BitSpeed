using UnityEngine;
public class LaserBeam : MonoBehaviour
{
    [SerializeField] private float distanceLaser = 100;
    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        ShootLaser();
    }

    private void ShootLaser()
    {
        if (IsTouchRaycast())
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);
            DrawRay(transform.position, hit.point);
            return;
        }
        DrawRay(transform.position, transform.right * distanceLaser);
    }

    private bool IsTouchRaycast()
    {
        return Physics2D.Raycast(transform.position, transform.right);
    }

    private void DrawRay(Vector2 startPos, Vector2 endPos)
    {
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }
}
