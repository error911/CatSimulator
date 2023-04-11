using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private LoaderView loaderViewPref;
    private LoaderView loaderView;


    void Start()
    {
        DontDestroyOnLoad(this);

        CreateLoaderView();
        StartCoroutine(LoadAsyncScene());
    }

    private void CreateLoaderView()
    {
        loaderView = Instantiate(loaderViewPref);
    }

    private IEnumerator LoadAsyncScene()
    {
        var asyncLoad = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            loaderView.SetProgress(asyncLoad.progress);
            yield return new WaitForSeconds(1);

            if (asyncLoad.progress >= 0.9f)
            {
                asyncLoad.allowSceneActivation = true;
            }

            yield return null;
        }
    }


}
