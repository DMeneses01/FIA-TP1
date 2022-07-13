using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class CarDetectorScript : MonoBehaviour {

	public float angle = 360;
	public bool ApplyThresholds, ApplyLimits;
	public float MinX, MaxX, MinY, MaxY;
	private bool useAngle = true;

	public float output;
	public int numObjects;

	void Start()
	{
		output = 0;
		numObjects = 0;

		if (angle > 360)
		{
			useAngle = false;
		}
	}

	void Update()
	{
		// YOUR CODE HERE

		GameObject[] cars = null;

		if (useAngle) {		// se tiver angulo especifico, ver carros nesse angulo
			cars = GetVisibleCars();
		}
		else {				// se nao, ver todos
			cars = GetAllCars();
		}

		output = 0;
		numObjects = cars.Length;

		GameObject closestCar = null;
		float aux = 0;

		foreach (GameObject car in cars)
		{
			// formula da energia
			output += 1.0f / ((transform.position - car.transform.position).sqrMagnitude + 1);
	

			if (closestCar == null) {	// se for o primeiro, sera este a ter como referencia
				closestCar = car;		
				aux = output;
			}
			else {						// se nao, temos de ver se a energia é superior à que temos como referencia
				if (output > aux){
					closestCar = car;
					aux = output;
				}
            }

		}

		output = aux;



	}

	public virtual float GetOutput() { throw new NotImplementedException(); }

	// Returns all "CarToFollow" tagged objects. The sensor angle is not taken into account.
	GameObject[] GetAllCars()
	{
		return GameObject.FindGameObjectsWithTag("CarToFollow");
	}

	// YOUR CODE HERE

	// Returns all "CarToFollow" tagged objects that are within the view angle of the Sensor. 
	// Only considers the angle over the y axis. Does not consider objects blocking the view.
	GameObject[] GetVisibleCars()
	{
		ArrayList visibleCars = new ArrayList();
		float halfAngle = angle / 2.0f;

		GameObject[] cars = GameObject.FindGameObjectsWithTag("CarToFollow"); 

		foreach (GameObject car in cars)
		{
			Vector3 toVector = (car.transform.position - transform.position);
			Vector3 forward = transform.forward;
			toVector.y = 0;
			forward.y = 0;
			float angleToTarget = Vector3.Angle(forward, toVector);

			if (angleToTarget <= halfAngle)
			{
				visibleCars.Add(car);
			}
		}

		return (GameObject[])visibleCars.ToArray(typeof(GameObject));
	}


}
