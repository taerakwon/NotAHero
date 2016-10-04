/* 
 * FILE: MainMenuController.cs
 * AUTHOR: TAERA KWON
 * LAST MODIFIED BY: TAERA kWON
 * LAST MODIFIED DATE: OCT 2, 2016
 * PROGRAM DESCRIPTION: INSTRUCTION SCENE CONTROLLER
 * REVISION HISTORY
 * 20161002: 	FOR MAIN MENU SCENE - HAVE BUTTONS THAT LOADS GAME OR MAIN INSTRUCTION SCENE
 * 				
*/


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
