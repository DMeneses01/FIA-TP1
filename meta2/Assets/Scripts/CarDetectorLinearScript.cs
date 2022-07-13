using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class CarDetectorLinearScript : CarDetectorScript {

	public override float GetOutput()
	{

		if (ApplyThresholds) // se os limiares estiverem ativos
		{
			if (output < MinX || output > MaxX) output = MinY;
			//quando o valor passa dos valores de máximo e minimo de x, o output passa ao valor minimo de y
		}

		if (ApplyLimits)  // se os limites estiverem ativos
		{
			if (output > MaxY) output = MaxY; //quando o valor passa o valor maximo de y, o output passa ao valor maximo de y

			if (output < MinY) output = MinY; //quando o valor passa o valor minimo de y, o output passa ao valor minimo de y
		}

		return 1- output;
	}




}
