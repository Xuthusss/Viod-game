using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Event musicEvent = null;
    private void Start()
    {
        musicEvent.Post(this.gameObject);
    }

    public void StartGame()//Load level 1 by press to start 
    {
        musicEvent.Stop(this.gameObject, 500, AkCurveInterpolation.AkCurveInterpolation_Constant);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
