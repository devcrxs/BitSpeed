using UnityEngine;
public class Contract : MonoBehaviour
{
    [SerializeField] private string nameNextScene;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(PlayerConstants.TAG_PLAYER))
        {
            EffectsManager.instance.InstantiateContract(transform.position);
            SoundsManager.instance.PlayGetContract();
            GameManager.instance.WinLevel(nameNextScene);
            gameObject.SetActive(false);
        }
    }
}
