using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStats : MonoBehaviour
{
    private const float DAMAGE_PER_ROUND = 1.0f;
    public const float MAX_TTL = 2f;
    public const float MIN_TTL = 0.5f;

    public Vector2 m_position;
    public Vector2 m_velocity;
	public bool m_alive;
	public float m_ttl;

	public void Start()
	{
		SetTTL(Random.Range(MIN_TTL, MAX_TTL));
		SetAlive(true);
	}

	public void SetPosition(Vector2 t_position) { m_position = t_position; }
	public void SetVelocity(Vector2 t_velocity) { m_velocity = t_velocity; }
	public void SetAlive(bool t_alive) { m_alive = t_alive; }
	public void SetTTL(float t_ttl) { m_ttl = t_ttl; }

	public Vector2 GetPosition() { return m_position; }
	public Vector2 GetVelocity() { return m_velocity; }

	public bool GetAlive() { return m_alive; }
	public float GetTTL() { return m_ttl; }
	public void DecreaseTTL() { m_ttl -= Time.deltaTime; }
	public void CheckAlive()
	{
		if(m_ttl <= 0.0f)
		{
			m_alive = false;
		}
	}
}
