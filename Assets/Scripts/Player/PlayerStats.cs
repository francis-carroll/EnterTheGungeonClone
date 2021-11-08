using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public const float MAX_HEALTH = 100.0f;
    public const int MAX_BULLETS_PER_MAG = 10;
    public Vector2 INITIAL_POSITION = new Vector2(0f, 0f);

    public float m_health;
    public Vector2 m_position;
    public int m_currentBulletCount;

    public bool m_autoReload = true;

    private void Start()
	{
        ResetHealth();
        ResetPosition();
	}

	public float GetMaxHealth() { return MAX_HEALTH; }
    public float GetCurrentHealth() { return m_health; }
    public Vector2 GetCurrentPosition() { return m_position; }
    public bool GetAutoReload() { return m_autoReload; }
    public int GetBulletCount() { return m_currentBulletCount; }
    public int GetMaxBulletsPerMag() { return MAX_BULLETS_PER_MAG; }

    public void SetCurrentHealth(float t_health) { m_health = t_health; }
    public void SetCurrentPosition(Vector2 t_position) { m_position = t_position; }
    public void SetBulletCount(int t_bulletCount) { m_currentBulletCount = t_bulletCount; }

    public void IncreaseHealth(float t_amount) { m_health += t_amount; }
    public void DecreaseHealth(float t_amount) { m_health -= t_amount; }
    public void ResetHealth () { m_health = MAX_HEALTH; }
    public void ResetPosition () { m_position = INITIAL_POSITION; }
}
