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
	Vector3 initialPosition;
	
	void Start()
	{
		virtualFramingTransposer = movingCamera.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>();
	}

	public void VibrateForTime(float time)
	{
		ShakeTime = time;
	}

	private void Update()
	{
		initialPosition = virtualFramingTransposer.m_TrackedObjectOffset;
		/*Debug.Log(initialPosition);*/
		if (ShakeTime > 0)
		{
			virtualFramingTransposer.m_TrackedObjectOffset = Random.insideUnitSphere * ShakeAmount + initialPosition;
			ShakeTime -= Time.deltaTime;
		}
		else
		{
			ShakeTime = 0.0f;
			virtualFramingTransposer.m_TrackedObjectOffset = Vector3.zero;//initialPosition;
		}
	}
	

}
