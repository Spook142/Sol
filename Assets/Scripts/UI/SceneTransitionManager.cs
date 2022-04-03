using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public FadeScreen fader;

    public void GoToScene(int sceneIndex)
    {
        StartCoroutine(GotoSceneRoutine(sceneIndex));
    }

    IEnumerator GotoSceneRoutine(int sceneIndex)
    {
        fader.FadeOut();
        yield return new WaitForSeconds(fader.fadeDuration);
        SceneManager.LoadScene(sceneIndex);
    }
}
