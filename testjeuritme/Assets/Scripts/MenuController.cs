using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    public GameObject Son;
    public void ChangeScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
        Instantiate(Son, transform.position, transform.rotation);
    }

    public void Quit()
    {
        Application.Quit();
        Instantiate(Son, transform.position, transform.rotation);
    }

    public void ActiveCanvas(GameObject _Name)
    {
        _Name.SetActive(true);
        Instantiate(Son, transform.position, transform.rotation);
    }

    public void DesactiveCanvas(GameObject _Name)
    {
        _Name.SetActive(false);
        Instantiate(Son, transform.position, transform.rotation);
    }
        
}
