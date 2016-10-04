using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InstructionController : MonoBehaviour {

	// Public Method To Start The Game
	public void Start_Click()
	{
		SceneManager.LoadScene ("GameScene");
	}
	// Public Method To Go Back To Main
	public void MainMenu_Click()
	{
		SceneManager.LoadScene ("MainMenu");
	}
}
