using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(RestartLevel);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}