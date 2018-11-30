using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingScene : MonoBehaviour
{
    private const int startingSceneIndex = 0;
    private const int mainSceneIndex = 1;
    private Animator animator;
    private int submitAnimTrigger = Animator.StringToHash(nameof(submitAnimTrigger));

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void StartButtonClicked()
    {
        animator.SetTrigger(submitAnimTrigger);
    } 

    public void BeginButtonClicked()
    {
        animator.SetTrigger(submitAnimTrigger);
    }

    private void LoadMainScene()
    {
        SceneManager.LoadScene(mainSceneIndex);
    }

    private IEnumerator BeginLoading()
    {

        //yield return new WaitForSeconds(0.5f);

        AsyncOperation asyncOp = SceneManager.LoadSceneAsync(mainSceneIndex, LoadSceneMode.Additive);

        while (!asyncOp.isDone)
        {
            //progressSlider.value = async.progress;

            if (asyncOp.progress > 0 && asyncOp.progress < 1)
                yield return new WaitForSeconds(0.1f);

            yield return null;
        }

        // progressSlider.value = async.progress;

        yield return new WaitForSeconds(0.5f);
        
     //   SceneManager.UnloadSceneAsync(startingSceneIndex);
    }
}
