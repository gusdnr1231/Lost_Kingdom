using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public string currentSceneName;
    Transform PlayerTransform;

	void Start()
    {
        DontDestroyOnLoad(gameObject);
        currentSceneName = SceneManager.GetActiveScene().name;
        PlayerTransform = GetComponent<Transform>();
    }
}
