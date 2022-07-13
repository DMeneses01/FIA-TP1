using UnityEngine;
using System.Collections;

public class CarBehaviour2a : CarBehaviour {
	
	void LateUpdate()
	{
		// YOUR CODE HERE
		float leftSensor = 0, rightSensor = 0;

		//Read sensor values
		if (DetectLights) //em caso de ativacao do Detect Lights
        {
			leftSensor = LeftLD.GetOutput(); //sensor esquerdo
			rightSensor = RightLD.GetOutput(); //sensor direito
		}

		if (DetectCars) //em caso de ativacao do Detect Cars
		{
			leftSensor = LeftCD.GetOutput(); //sensor esquerdo
			rightSensor = RightCD.GetOutput(); //sensor direito
		}
		

		//Calculate target motor values
		m_LeftWheelSpeed = leftSensor * MaxSpeed;
		m_RightWheelSpeed = rightSensor * MaxSpeed;
	}
}
