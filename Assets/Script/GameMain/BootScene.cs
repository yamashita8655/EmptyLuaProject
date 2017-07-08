using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class BootScene : MonoBehaviour {
	[SerializeField] Canvas MainCanvas;
	[SerializeField] Text OutputText;
	[SerializeField] Button TriggerButton;

	private string StartDebugLog = "";
	private string ClickDebugLog = "";

	enum BitTest {
		None = 0,
		One = 1,
		Two = 1 << 1,
		Both = One | Two,
		Three = 1 << 2,
		Four = 1 << 3,
	}

	BitTest bitTest = BitTest.None;

	// Use this for initialization
	void Start () {
		Debug.Log((int)BitTest.None);
		Debug.Log((int)BitTest.One);
		Debug.Log((int)BitTest.Two);
		Debug.Log((int)BitTest.Three);
		Debug.Log((int)BitTest.Four);
		Debug.Log((int)BitTest.Both);

		bitTest = BitTest.One|BitTest.Two;
		if ((bitTest & BitTest.One) == BitTest.One) {
			Debug.Log("One");
		}
		if ((bitTest & BitTest.Two) == BitTest.Two) {
			Debug.Log("Two");
		}
		if ((bitTest & BitTest.Three) == BitTest.Three) {
			Debug.Log("Three");
		}
		if ((bitTest & BitTest.Four) == BitTest.Four) {
			Debug.Log("Four");
		}
		if ((bitTest & BitTest.Both) == BitTest.Both) {
			Debug.Log("Both");
		}

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
