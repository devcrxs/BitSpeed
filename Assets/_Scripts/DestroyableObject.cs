using UnityEngine;
public class DestroyableObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsBullet(other))
        {
            EffectsManager.instance.InstantiateDestroyableObject(transform.position);
            gameObject.SetActive(false);
        }
    }

    private bool IsBullet(Collider2D other)
    {
        return other.CompareTag(Constans.TAG_BULLET);
    }
}
