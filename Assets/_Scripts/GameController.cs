/* 
 * FILE: GameController.cs
 * AUTHOR: TAERA KWON
 * LAST MODIFIED BY: TAERA kWON
 * LAST MODIFIED DATE: OCT 3, 2016
 * PROGRAM DESCRIPTION: GAME CONTROLLER CLASS FOR MAIN GAME'S CONTROL
 * REVISION HISTORY
 * 20161002: 	CREATED
 * 				HEALTH, MONEY, SCORE SYSTEM BEHAVIOUR ADDED
 * 				REMOVAL OF OBJECTS WHEN GAME ENDS
 * 				END SOUND ADDED
 * 20161003:	SCENE MANAGEMENT ADDED
 * 				SCORING SYSTEM UPDATED
 * 				
*/


using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// GAME CONTROLLER
public class GameController : MonoBehaviour {
    // PRIVATE INSTANCE VARIABLES
    private int _healthValue;
    private int _moneyValue;
	private int _scoreValue;

    // PUBLIC INSTANCE VARIABLES
    public int droneNumber = 7;
    public GameObject drone;    

	// HEADER FOR TEXT LABELS
    [Header("Labels")]
    public Text HealthLabel;
    public Text MoneyLabel;
	public Text ScoreLabel;
	public Text FinalScoreLabel;
	public Text GameOverLabel;

	[Header("Game Objects")]
	public GameObject JetPlane;
	public GameObject Money;
	public GameObject Laser;

	// HEADER FOR BUTTONS
	[Header("Buttons")]
	public Button RestartButton;
	public Button MainMenuButton;

	// HEADER FOR END GAME SOUND
	[Header("End Game Sound")]
	public AudioSource EndSound = new AudioSource ();

    // PUBLIC METHODS
	// UPDATES HEALTH VALUE
    public int HealthValue
    {
        get{
            return this._healthValue;
        }
        set
        {
            this._healthValue = value;
			if (this._healthValue <= 0) {
				this._endGame ();
			} else {
				this.HealthLabel.text = "HEALTH: " + this._healthValue + " %";
			}
        }
    }

	// UPDATES MONEY VALUE
        public int MoneyValue
    {
        get{
            return this._moneyValue;
        }
        set
        {
            this._moneyValue = value;
			if (this._moneyValue <= 0) {
				this._endGame ();
			} else {
				this.MoneyLabel.text = "MONEY: " + this._moneyValue;
			}
        }
    }

	// UPDATES SCORE VALUE
	public int ScoreValue
	{
		get{
			return this._scoreValue;
		}
		set{
			this._scoreValue = value;
			this.ScoreLabel.text = "SCORE: " + this._scoreValue;
		}
	}


	// Use this for initialization
	void Start () {
		this._moneyValue = 1000;
		this._healthValue = 100;
		this._scoreValue = 0;
		this.GameOverLabel.gameObject.SetActive(false);
		this.FinalScoreLabel.gameObject.SetActive (false);
		this.RestartButton.gameObject.SetActive (false);
		this.MainMenuButton.gameObject.SetActive (false);

        for (int droneCount = 0; droneCount < this.droneNumber; droneCount++)
        {
            Instantiate(this.drone);
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	}


	// End Game Method
	private void _endGame()
	{
		if (this._moneyValue == 0 || this._healthValue == 0) {
			this.GameOverLabel.gameObject.SetActive (true);
			this.FinalScoreLabel.text = "FINAL SCORE: " + this.ScoreValue;
			this.FinalScoreLabel.gameObject.SetActive (true);
			this.HealthLabel.gameObject.SetActive (false);
			this.MoneyLabel.gameObject.SetActive (false);
			this.ScoreLabel.gameObject.SetActive (false);
			this.JetPlane.gameObject.SetActive (false);
			this.Laser.gameObject.SetActive (false);
			this.Money.gameObject.SetActive (false);
			this.RestartButton.gameObject.SetActive (true);
			this.MainMenuButton.gameObject.SetActive (true);
			this.EndSound.Play ();
		}

	}

	// Public Restart Game
	public void RestartGame()
	{
		SceneManager.LoadScene ("GameScene");		
	}

	// Public MainMenu_Click Method
	public void MainMenu_Click()
	{
		SceneManager.LoadScene ("MainMenu");
	}


}

