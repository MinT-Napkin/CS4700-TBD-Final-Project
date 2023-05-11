using UnityEngine;
using UnityEngine.SceneManagement;

public class ThankYouTransition : MonoBehaviour
{
    public string sceneName; // The name of the scene to transition to

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName); // Load the specified scene
        }
    }
}
