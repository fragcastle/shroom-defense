using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
	public float SpawnRate = 3;
	public float SpawnRateDelay = 3;
	
	public Transform SmallGroundEnemy;
	public Transform MediumGroundEnemy;
	public Transform LargeGroundEnemy;
	
	public int SpawnIndex = 0;
	
	public int[] SpawnSequence = new int[] { 0, 0, 0, 0, 0, 1, 1, 1, 1, 1 };
	
	void Start ()
	{
		
	}
	
	void Update ()
	{
		if (SpawnIndex >= SpawnSequence.Length)
			return;
			
		SpawnRateDelay -= Time.deltaTime;
		
		if (SpawnRateDelay <= 0)
		{
			Transform groundEnemy = null;
			
			if (SpawnSequence[SpawnIndex] == 0)
				groundEnemy = (Transform)Instantiate(SmallGroundEnemy);
			else if (SpawnSequence[SpawnIndex] == 1)
				groundEnemy = (Transform)Instantiate(MediumGroundEnemy);
			else if (SpawnSequence[SpawnIndex] == 2)
				groundEnemy = (Transform)Instantiate(LargeGroundEnemy);
			
			groundEnemy.position = transform.position;
			
			SpawnIndex++;
			
			SpawnRateDelay = SpawnRate;
		}
	}
}
