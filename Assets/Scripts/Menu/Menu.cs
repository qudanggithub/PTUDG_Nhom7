using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    private bool isPaused = false;
    public void choimoi()
    {
        SceneManager.LoadScene(1);
    }

    public void thoat()
    {
        Application.Quit();
    }

    public void pause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; 
            
        }
        else
        {
            Time.timeScale = 1f; 
            
        }
    }

}
