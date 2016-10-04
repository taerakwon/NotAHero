using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {


	// PUBLIC START BUTTON METHOD
	public void StartButton_Click()
	{
		SceneManager.LoadScene ("GameScene");
	}

	// PUBLIC INSTRUCTION BUTTON METHOD
	public void InstructionButton_Click()
	{
		SceneManager.LoadScene ("InstructionScene");
	}
}
