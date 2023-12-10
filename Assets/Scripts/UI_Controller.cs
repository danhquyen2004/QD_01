using UnityEngine.SceneManagement;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    [SerializeField] GameObject tutorial;
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Home()
    {
        SceneManager.LoadScene(0);
    }
    public void RePlay()
    {
        string CurrentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(CurrentScene);
    }
    public void Tutorial()
    {
        if(!tutorial.activeInHierarchy)
        {
            tutorial.SetActive(true);
        }
        else { tutorial.SetActive(false); }
        
    }
}
