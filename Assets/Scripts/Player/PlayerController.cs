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

		ResetBulletCount();
	}

	public void LateUpdate()
	{
		MovePlayer();

		transform.position = m_playerStats.GetComponent<PlayerStats>().GetPosition();

		ApplyFriction();
	}

	public void Shoot(Vector2 t_mousePosition)
	{
		if(m_playerStats.GetBulletCount() > 0)
		{
			GameObject bullet = Instantiate(m_bulletinstance, transform);
			bullet.GetComponent<BulletStats>().SetPosition(m_playerStats.GetPosition());
			bullet.GetComponent<BulletStats>().SetVelocity(-(m_playerStats.GetPosition() - (Vector2)Camera.main.ScreenToWorldPoint(t_mousePosition)).normalized * m_playerStats.GetBulletSpeed());
			m_playerStats.DecreaseBulletCount(1);
		}
	}

	public void ResetBulletCount()
	{
		m_playerStats.SetBulletCount(m_playerStats.GetMaxBulletsPerMag());
	}

	public void MoveForward()
	{
		m_playerStats.SetVelocity(new Vector2(m_playerStats.GetVelocity().x, 1 * m_playerStats.GetSpeed()));
	}

	public void MoveLeft()
	{
		m_playerStats.SetVelocity(new Vector2(-1 * m_playerStats.GetSpeed(), m_playerStats.GetVelocity().y));
	}

	public void MoveBack()
	{
		m_playerStats.SetVelocity(new Vector2(m_playerStats.GetVelocity().x, -1 * m_playerStats.GetSpeed()));
	}

	public void MoveRight()
	{
		m_playerStats.SetVelocity(new Vector2(1 * m_playerStats.GetSpeed(), m_playerStats.GetVelocity().y));
	}

	public void MovePlayer()
	{
		m_playerStats.SetPosition(m_playerStats.GetPosition() + (Time.deltaTime * m_playerStats.GetVelocity()));
	}

	public void ApplyFriction()
	{
		if(Vector2.Distance(m_playerStats.GetVelocity(), new Vector2(0f,0f)) < 0.5f)
		{
			m_playerStats.SetVelocity(new Vector2(0f, 0f));
		}
		else
		{
			m_playerStats.SetVelocity(m_playerStats.GetVelocity() * 0.99f);
		}
	}
}
