using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private PlayerStats m_playerStats;

	[SerializeField]
	private GameObject m_bulletinstance;


	private void Start()
	{
		m_playerStats = this.GetComponent<PlayerStats>();
		m_bulletinstance = Resources.Load("Prefabs/Bullet") as GameObject;
	}

	public void Shoot(Vector2 t_mousePosition)
	{
		GameObject bullet = Instantiate(m_bulletinstance, transform);
		bullet.GetComponent<BulletStats>().SetPosition(m_playerStats.GetCurrentPosition());
		bullet.GetComponent<BulletStats>().SetVelocity(-(m_playerStats.GetCurrentPosition() - (Vector2)Camera.main.ScreenToWorldPoint(t_mousePosition)).normalized * 10.0f);
	}

	public void ResetBulletCount()
	{
		m_playerStats.SetBulletCount(m_playerStats.GetMaxBulletsPerMag());
	}

	public void MoveForward()
	{
		
	}

	public void MoveLeft()
	{

	}

	public void MoveRight()
	{

	}

	public void MoveBack()
	{

	}
}
