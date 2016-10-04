using UnityEngine;
using System.Collections;

public class LaserController : MonoBehaviour {
	// PRIVATE VARIABLES 
	private int _laserSpeed;
	private Transform _transform;
	private int _timeReload;

	// PUBLIC VARIABLES
	public GameObject JetPlane;

	public GameController gameController;

	// Use this for initialization
	void Start () {
		// Get Transform Component of Laser
		this._transform = this.GetComponent<Transform>();
		this._timeReload = 30;
		this._reset ();
	}
	
	// Update is called once per frame
	void Update () {
		this._move ();
		this._checkBoundary ();
		this._timeReload -= 1;
	}

	// Checks boundary of game object
	private void _checkBoundary()
	{
		if (this._timeReload <= 0)
		{
			this._reset();
		}
	}

	// HOW LASER MOVE
	private void _move()
	{
		// Take current position and put into new position
		Vector2 newPosition = this._transform.position;
		newPosition.x += this._laserSpeed;
		// Assigning newPosition to this (SKyBackground's) position
		this._transform.position = newPosition;
	}		

	// ON TRIGGER RESPONSE
	private void OnTriggerEnter2D(Collider2D collide)
	{
		// If Laser Strucks Drone WHen Visible
		if (this._transform.position.x < 290) {
			if (collide.gameObject.CompareTag ("Drone")) {		
				DroneController dc = (DroneController)collide.GetComponent (typeof(DroneController));
				dc.Destroy ();
				this.gameController.MoneyValue += 10;
				this.gameController.ScoreValue += 1;
				this._transform.position = new Vector2 (360, 0);
			}
		}
	}

	// RESETS LASER RELATIVE TO JETPLANE POSITION
	private void _reset()
	{
		Transform jetTransform = JetPlane.GetComponent<Transform> ();
		// Changes the speed of drone moving left
		this._laserSpeed = 20;
		this._transform.position = new Vector2(jetTransform.position.x + 100, jetTransform.position.y + 8);
		this._timeReload = 30;
	}
}
