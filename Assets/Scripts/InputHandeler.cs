using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandeler : MonoBehaviour
{
	private GameObject m_player;

	public void Start()
	{
		m_player = GameObject.FindGameObjectWithTag("Player");
	}

	public void Update()
	{
		PlayerInput();
	}

	public void PlayerInput()
	{
		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			m_player.GetComponent<PlayerController>().MoveForward();
		}

		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			m_player.GetComponent<PlayerController>().MoveLeft();
		}

		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			m_player.GetComponent<PlayerController>().MoveBack();
		}

		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			m_player.GetComponent<PlayerController>().MoveRight();
		}

		if(Input.GetMouseButton(0))
		{
			m_player.GetComponent<PlayerController>().Shoot(Input.mousePosition);
		}
	}
}
