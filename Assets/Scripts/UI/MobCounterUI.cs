using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MobCounterUI : MonoBehaviour
{
	int killCount; // ���� �󸶳� �׿���
	int spawnCount; // ���� �󸶳� ��ȯ�ƴ���
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

	public void OnSpawn() // �ܺο��� ��
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
