using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class BootScene : MonoBehaviour {
	[SerializeField] Canvas MainCanvas;

	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 60;
		StartCoroutine(CoroutineStart());
	}

	private IEnumerator CoroutineStart() {
		GameSceneManager.Instance.Initialize();
		GameObjectCacheManager.Instance.Initialize();
		AssetBundleManager.Instance.Initialize();
		ResourceManager.Instance.Init();
		RijindaelManager.Instance.Init();
		VersionFileManager.Instance.Initialize();

		yield return StartCoroutine(LuaInit());
	}

	IEnumerator LuaInit() {
		float factor = MainCanvas.scaleFactor;
		yield return StartCoroutine(UnityUtility.Instance.Init());
	}
}
