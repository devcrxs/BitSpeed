using UnityEngine;
using UnityEngine.SceneManagement;
public class SaveLevel : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetString(KeysPlayerPrefs.KEY_LEVEL_SAVE,SceneManager.GetActiveScene().name);
    }
}
