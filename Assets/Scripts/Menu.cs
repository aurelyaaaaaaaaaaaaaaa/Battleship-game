using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //Loads the help scene
    public void PlayGame()
    {
        SceneManager.LoadScene(4);
    }
}
