using UnityEngine.SceneManagement;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    //Loads the game scene
    void Start()
    {
        SceneManager.LoadScene(1);
    }
}
