using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeEffect : MonoBehaviour
{
	public float ShakeAmount;
	float ShakeTime;
	CinemachineFramingTransposer virtualFramingTransposer;
	[SerializeField] GameObject movingCamera;
	
	void Start()
	{
		virtualFramingTransposer = movingCamera.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>();
	}

	public void VibrateForTime(float time)
	{
		ShakeTime = time;
		StartCoroutine(TimeStop());
	}

	private void Update()
	{
		if (ShakeTime > 0)
		{
			virtualFramingTransposer.m_TrackedObjectOffset = new Vector3(Random.Range(-1f,1.1f) * ShakeAmount, Random.Range(-1f, 1.1f) * ShakeAmount,0);
			ShakeTime -= Time.deltaTime;
		}
		else
		{
			ShakeTime = 0.0f;
			virtualFramingTransposer.m_TrackedObjectOffset = Vector3.zero;
		}
	}
	
	IEnumerator TimeStop()
	{
		Debug.Log("Ω√∞£ ∏ÿ√„");
		Time.timeScale = 0;
		yield return new WaitForSecondsRealtime(0.01f);
		Time.timeScale = 1;
	}
}
