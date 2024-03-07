using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{   
    public void LoadNextScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}