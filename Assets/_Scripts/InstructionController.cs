/* 
 * FILE: InstructionController.cs
 * AUTHOR: TAERA KWON
 * LAST MODIFIED BY: TAERA kWON
 * LAST MODIFIED DATE: OCT 3, 2016
 * PROGRAM DESCRIPTION: INSTRUCTION SCENE CONTROLLER
 * REVISION HISTORY
 * 20161002: 	FOR INSTRUCTION SCENE - HAVE BUTTONS THAT LOADS GAME OR MAIN MENU SCENE
 * 20161003:	UPDATED INSTRUCTION DETAILS
 * 				
*/

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
