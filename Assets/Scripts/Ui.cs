using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ui : MonoBehaviour
{
	PlayerController _playerController;
	
	Text _life;
	Text _money;
	
	void Start ()
	{
		_playerController = GameObject.Find("PlayerController").GetComponent<PlayerController>();
		
		_life = GameObject.Find("Life").GetComponent<Text>();
		_money = GameObject.Find("Money").GetComponent<Text>();
	}
	
	void Update ()
	{
		
	}
	
	void OnGUI()
	{
		if (_playerController)
		{
			_life.text = _playerController.Life.ToString();
			_money.text = "$" + _playerController.Money.ToString();
		}
	}
}
