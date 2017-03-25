using UnityEngine;

public static class RandomArray 
{
	public static bool[] GetRandomArray(int length)
	{
		int[] randomIntArray = new int[length];

		for (int i = 0; i < length; i++) {
			randomIntArray [i] = Random.Range (0, 2);
		}

		bool[] randomBoolArray = new bool[length];

		for (int i = 0; i < length; i++) 
		{
			if (randomIntArray [i] == 0) 
			{
					randomBoolArray [i] = false;
			} 
			else 
			{
					randomBoolArray [i] = true;
			}

			if (i > 1 && (randomBoolArray [i - 2] == randomBoolArray [i - 1]) && (randomBoolArray [i - 1] == randomBoolArray[i])) 
			{
				randomBoolArray [i] = !randomBoolArray [i];
			}
		}

		return randomBoolArray;
	}
}
