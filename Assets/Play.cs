using UnityEngine;
using UnityEngine.SceneManager

public class Play : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PlayGame() {
        SceneManager.LoadScene(1);
    }
}
