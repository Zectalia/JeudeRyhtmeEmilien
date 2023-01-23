using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    public void ChangeScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ActiveCanvas(GameObject _Name)
    {
        _Name.SetActive(true);
    }

    public void DesactiveCanvas(GameObject _Name)
    {
        _Name.SetActive(false);
    }
        
}
