using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject startButton;
    public GameObject quitButton;

    private Button start;
    private Button quit;

    private Animator startButtonAnim;
    private Animator quitButtonAnim;

    private void Start() 
    {
        startButtonAnim = startButton.GetComponent<Animator>();
        quitButtonAnim = quitButton.GetComponent<Animator>();

        start = startButton.GetComponent<Button>();
        quit = quitButton.GetComponent<Button>();
    }

    public void PlayGame()
    {
        print("Pressed start");
        start.interactable = false;
        startButtonAnim.Play("Selected");
        StartCoroutine(WaitForPlayAnimation(startButtonAnim));
    }

    public void QuitGame()
    {
        print("Pressed quit");
        quit.interactable = false;
        quitButtonAnim.Play("Selected");
        StartCoroutine(WaitForQuitAnimation(quitButtonAnim));
    }

    private IEnumerator WaitForPlayAnimation(Animator anim)
    {
        yield return new WaitForSeconds(0.5f);

        // Wait for the animation to finish playing
        while (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        // Wait for the new scene to finish loading
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    
    
    private IEnumerator WaitForQuitAnimation(Animator anim)
    {

        // Wait for the animation to finish playing
        while (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return null;
        }

        print("Quit!");
        Application.Quit();
    }
}