using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
	public int proximaCenaIndex;
	void OnEnable()
	{
		SceneManager.LoadScene(proximaCenaIndex);
	}
}
