using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public void EndGame()
    {
        Debug.Log("Game Over");
        //Change scene name to game over scene
        SceneManager.LoadScene("Cave kit Demo");
    }
}
