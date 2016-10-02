using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    // PRIVATE INSTANCE VARIABLES
    private int _healthValue;
    private int _moneyValue;
	private int _scoreValue;


    // PUBLIC INSTANCE VARIABLES
    public int droneNumber = 3;
    public GameObject drone;
    

    [Header("Labels")]
    public Text HealthLabel;
    public Text MoneyLabel;
	public Text ScoreLabel;
	public Text FinalScoreLabel;
	public Text GameOverLabel;

	[Header("Game Objects")]
	public GameObject JetPlane;
	public GameObject Money;

	[Header("Buttons")]
	public Button RestartButton;

    // PUBLIC METHODS
    public int HealthValue
    {
        get{
            return this._healthValue;
        }
        set
        {
            this._healthValue = value;
			this.HealthLabel.text = "HEALTH: " + this._healthValue + " %";
        }
    }

        public int MoneyValue
    {
        get{
            return this._moneyValue;
        }
        set
        {
            this._moneyValue = value;
			this.MoneyLabel.text = "MONEY: " + this._moneyValue;
        }
    }

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

        for (int droneCount = 0; droneCount < this.droneNumber; droneCount++)
        {
            Instantiate(this.drone);
        }
	
	}
	
	// Update is called once per frame
	void Update () {
		this._endGame ();
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
			this.Money.gameObject.SetActive (false);
			this.RestartButton.gameObject.SetActive (true);
		}		
	}
}

