using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void soundBasics()
    {
        SceneManager.LoadScene("SoundBasics");
    }

    public void soundBehaviours()
    {
        SceneManager.LoadScene("SoundBehaviours");
    }

    public void soundAndEars()
    {
        SceneManager.LoadScene("SoundsAndEars");
    }

    public void dopplerEffect()
    {
        SceneManager.LoadScene("DopplerEffect");
    }

    public void soundLayers()
    {
        SceneManager.LoadScene("SoundLayers");
    }

    public void musicAndTheBrain()
    {
        SceneManager.LoadScene("MusicAndTheBrain");
    }

}
