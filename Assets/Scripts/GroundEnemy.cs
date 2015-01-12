using UnityEngine;
using System.Collections;

public class GroundEnemy : EnemyBase
{
	private LevelPath _levelPath;
	private float _pathPosition = 0;
	private Vector3 _floorPosition;
	
	private float _lookAheadAmount = .01f;
	private RaycastHit hit;
	private float rayLength = 20;
	
	void Start ()
	{
		_levelPath = GameObject.Find("LevelPath").GetComponent<LevelPath>();
	}
	
	void Update ()
	{
		_pathPosition += MoveSpeed * Time.deltaTime;
		
		if (_pathPosition > 1)
		{
			Destroy(gameObject);
			
			var playerController = GameObject.Find("PlayerController");
			
			if (playerController)
			{
				playerController.GetComponent<PlayerController>().Life--;
			}
		}
		
		var pathPercent = _pathPosition % 1;
		
		var lookTarget = iTween.PointOnPath(_levelPath.ControlPath, pathPercent + _lookAheadAmount);
		
		transform.LookAt(lookTarget);
		
		//nullify all rotations but y since we just want to look where we are going:
		var yRot = transform.eulerAngles.y;
		transform.eulerAngles = new Vector3(0, yRot, 0);
		
		var coordinateOnPath = iTween.PointOnPath(_levelPath.ControlPath, pathPercent);
		
		if (Physics.Raycast(coordinateOnPath, Vector3.down, out hit, rayLength))
		{
			Debug.DrawRay(coordinateOnPath, Vector3.down * hit.distance);
			_floorPosition = hit.point;
		}
		
		transform.position = new Vector3(_floorPosition.x, _floorPosition.y, _floorPosition.z);
	}
}
