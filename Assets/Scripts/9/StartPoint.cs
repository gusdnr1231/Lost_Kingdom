using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
	public string startPoint;
	private Player thePlayer;
	void Start()
	{
		if (thePlayer == null)
			thePlayer = FindObjectOfType<Player>();
		if (startPoint == thePlayer.currentSceneName)
		{
			thePlayer.transform.position = transform.position;
		}
	}
}
