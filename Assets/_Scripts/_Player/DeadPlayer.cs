using UnityEngine;
public class DeadPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(PlayerConstants.TAG_PLAYER))
        {
            StartCoroutine(GameManager.instance.WaitResetPlayer());
        }
    }
}
