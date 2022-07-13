using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class CarDetectorGaussScript : CarDetectorScript {

	public float stdDev = 1.0f; 
	public float mean = 0.0f; 
	// Get gaussian output value
	public override float GetOutput()
	{
		// formula da gaussiana
		float a = (float) (1 / (stdDev * (Math.Sqrt(2 * Math.PI))));
		float b = (float)((-1 / 2) * (Math.Pow(output - mean, 2) / Math.Pow(stdDev, 2)));

		float gauss = a * (float)Math.Exp(b);

		if (ApplyThresholds) // se os limiares estiverem ativos
		{
			if (gauss < MinX || gauss > MaxX) gauss = MinY;
			//quando o valor passa dos valores de máximo e minimo de x, o output passa ao valor minimo de y
		}

		if (ApplyLimits) // se os limites estiverem ativos
		{
			if (gauss > MaxY) gauss = MaxY; //quando o valor passa o valor maximo de y, o output passa ao valor maximo de y

			if (gauss < MinY) gauss = MinY; //quando o valor passa o valor minimo de y, o output passa ao valor minimo de y
		}

		return  gauss;
	}


}
