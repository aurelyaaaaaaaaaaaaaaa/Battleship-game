using UnityEngine.SceneManagement;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    //Loads the game scene
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
