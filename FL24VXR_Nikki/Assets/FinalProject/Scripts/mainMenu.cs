using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void soundBasics()
    {
        StartCoroutine(LoadSceneWithDelay("SoundBasics"));
    }

    public void soundBehaviours()
    {
        StartCoroutine(LoadSceneWithDelay("SoundBehaviours"));
    }

    public void soundAndEars()
    {
        StartCoroutine(LoadSceneWithDelay("SoundsAndEars"));
    }

    public void dopplerEffect()
    {
        StartCoroutine(LoadSceneWithDelay("DopplerEffect"));
    }

    public void soundLayers()
    {
        StartCoroutine(LoadSceneWithDelay("SoundLayers"));
    }

    public void musicAndTheBrain()
    {
        StartCoroutine(LoadSceneWithDelay("MusicAndTheBrain"));
    }

    private IEnumerator LoadSceneWithDelay(string sceneName)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
    }
}
