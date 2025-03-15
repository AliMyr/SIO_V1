using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public Image LoadingProgressBar;
    public float sceneActivationDelay = 1.0f; // Задержка перед активацией сцены

    private static SceneTransition instance;
    private static bool shouldPlayOpeningAnimation = false;

    private Animator componentAnimator;
    private AsyncOperation loadingSceneOperation;

    public static void SwitchToScene(string sceneName)
    {
        if (instance == null)
        {
            Debug.LogError("SceneTransition instance is missing in the scene!");
            return;
        }

        instance.componentAnimator.SetTrigger("sceneClosing");
        instance.StartSceneLoading(sceneName);
    }

    private void Start()
    {
        instance = this;
        componentAnimator = GetComponent<Animator>();

        if (shouldPlayOpeningAnimation)
        {
            componentAnimator.SetTrigger("sceneOpening");
            LoadingProgressBar.fillAmount = 1;
            shouldPlayOpeningAnimation = false;
        }
    }

    private void StartSceneLoading(string sceneName)
    {
        loadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);
        loadingSceneOperation.allowSceneActivation = false;
        LoadingProgressBar.fillAmount = 0;
    }

    private void Update()
    {
        if (loadingSceneOperation != null)
        {
            LoadingProgressBar.fillAmount = Mathf.Lerp(LoadingProgressBar.fillAmount, loadingSceneOperation.progress, Time.deltaTime * 5);
        }
    }

    public void OnAnimationOver()
    {
        shouldPlayOpeningAnimation = true;
        StartCoroutine(DelayedSceneActivation());
    }

    private IEnumerator DelayedSceneActivation()
    {
        yield return new WaitForSeconds(sceneActivationDelay);

        if (loadingSceneOperation != null)
        {
            loadingSceneOperation.allowSceneActivation = true;
        }
    }
}