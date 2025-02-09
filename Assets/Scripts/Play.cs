using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Play : MonoBehaviour
{

    void Update() {
        if (Input.anyKey) {
            PlayGame();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PlayGame() {
        SceneManager.LoadScene("DFSScene1");
    }
}
