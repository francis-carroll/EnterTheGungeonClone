using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private BulletStats m_bulletStats;
	private GameObject m_player;

	public void Start()
	{
		m_bulletStats = this.GetComponent<BulletStats>();
		m_player = GameObject.FindGameObjectWithTag("Player");
	}

	public void Update()
	{
		m_bulletStats.CheckAlive();
		AutomaticallyReload();
		m_bulletStats.DecreaseTTL();


		if(!m_bulletStats.GetAlive())
		{
			GameObject.Destroy(this.gameObject);
		}
	}

	public void LateUpdate()
	{
		MoveBullet();

		transform.position = m_bulletStats.GetComponent<BulletStats>().GetPosition();
	}

	public void AutomaticallyReload()
	{
		if (m_player.GetComponent<PlayerStats>().GetAutoReload() && m_player.GetComponent<PlayerStats>().GetBulletCount() <= 0)
		{
			Reload();
		}
	}

	public void Reload()
    {
		if(m_bulletStats.GetAlive())
		{
			m_player.GetComponent<PlayerController>().ResetBulletCount();
		}
    }

	public void MoveBullet()
	{
		m_bulletStats.SetPosition(m_bulletStats.GetPosition() + (Time.deltaTime * m_bulletStats.GetVelocity()));
	}
}
