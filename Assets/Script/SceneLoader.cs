using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    string _scenename;
    public void SceneLoad(string scenename)
    {
        _scenename = scenename;
        GameObject.Find("Explanation").GetComponent<Button>().enabled = false;
        Invoke("GameStart", 3.0f);
    }

    public void GameStart()
    {
        SceneManager.LoadScene(_scenename);
    }

    public void Sceneloaded(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }
}
