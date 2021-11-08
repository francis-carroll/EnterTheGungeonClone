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
		if(Input.GetKeyDown(KeyCode.W))
		{
			m_player.GetComponent<PlayerController>().MoveForward();
		}

		if (Input.GetKeyDown(KeyCode.A))
		{
			m_player.GetComponent<PlayerController>().MoveLeft();
		}

		if (Input.GetKeyDown(KeyCode.S))
		{
			m_player.GetComponent<PlayerController>().MoveBack();
		}

		if (Input.GetKeyDown(KeyCode.D))
		{
			m_player.GetComponent<PlayerController>().MoveRight();
		}

		if(Input.GetMouseButtonDown(0))
		{
			m_player.GetComponent<PlayerController>().Shoot(Input.mousePosition);
		}
	}
}
