using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MobCounterUI : MonoBehaviour
{
	int killCount; // 몹을 얼마나 죽였는
	int spawnCount; // 몹이 얼마나 소환됐는지
	TextMeshProUGUI textUI;

	private void Awake()
	{
		textUI = GetComponent<TextMeshProUGUI>();
	}

	void UpdateUI()
	{
		if (!enabled)
			return;
		textUI.text =
			$"Kill/Alive/Spawn\n{killCount}/" + $"{spawnCount - killCount}/{spawnCount}";
	}

	private void OnEnable()
	{
		killCount = spawnCount = 0;
		UpdateUI();
	}

	public void OnSpawn() // 외부에서 부
	{
		spawnCount++;
		UpdateUI();
	}

	public void OnKill()
	{
		killCount++;
		UpdateUI();
	}
}
