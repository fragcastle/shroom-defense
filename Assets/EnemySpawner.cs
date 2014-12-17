using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
	public float SpawnRate = 3;
	public float SpawnRateDelay = 3;
	
	public Transform GroundEnemy;
	public Transform HeavyGroundEnemy;
	
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
				groundEnemy = (Transform)Instantiate(GroundEnemy);
			else if (SpawnSequence[SpawnIndex] == 1)
				groundEnemy = (Transform)Instantiate(HeavyGroundEnemy);
			
			groundEnemy.position = transform.position;
			
			SpawnIndex++;
			
			SpawnRateDelay = SpawnRate;
		}
	}
}
