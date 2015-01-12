using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelPath : MonoBehaviour
{
	public Transform[] ControlPath;

	void Start ()
	{
	
	}
	
	void Update ()
	{
	
	}
	
	void OnDrawGizmos()
	{
		var pathPoints = new List<Transform>();
		
		foreach (Transform child in transform)
		{
			pathPoints.Add(child);
		}
		
		ControlPath = pathPoints.ToArray();
		
		iTween.DrawPath(ControlPath, Color.blue);	
	}	
}
