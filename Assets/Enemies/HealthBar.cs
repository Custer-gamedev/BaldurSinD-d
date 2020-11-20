using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	public Slider healthBarSlider;
	public EnemyStats eStats;
	private void Start()
	{
		eStats = GetComponent<EnemyStats>();
		healthBarSlider.maxValue = eStats.hp;

	}
	private void Update()
	{
		healthBarSlider.value = eStats.hp;

		if (eStats.hp <= 0)
			Destroy(healthBarSlider.gameObject);

	}
}

