using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    // PRIVATE INSTANCE VARIABLES 

    // PUBLIC PROPERTIES
    public int droneNumber = 3;
    public GameObject drone;
    

	// Use this for initialization
	void Start () {
        for (int droneCount = 0; droneCount < this.droneNumber; droneCount++)
        {
            Instantiate(this.drone);
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
