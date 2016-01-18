using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SceneCameraPositions : MonoBehaviour {

	public static SceneCameraPositions instance;
	
	
	[Header("Camera Settings")]
	[SerializeField]
	private Camera[] sceneCameras;
	
	[Header("UI Settings")]
	[SerializeField]
	private Sprite[] texts;

	private Button buttonLeft;
	private Button buttonRight;
	private Animator fadingAnimator;
	private Image textDisplay;

	private int currentScene;
	private int maxScene;
		
	private Dictionary<int, GameObject[]> sceneSpecificAssets;

	public void MoveCameraToNextPosition () {

		ActivateCurrentSceneAssets ();
		JumpToCurrentCamera ();
		UpdateTextToCurrentScene ();
	}

	private void JumpToCurrentCamera () {
		for (int i = 0; i < sceneCameras.Length; i++) {
			sceneCameras [i].gameObject.SetActive(currentScene == i);
		}
	}

	public void MoveToNextScene () {		
		currentScene ++;
		MoveMainCameraToCurrentScene ();
	}
	
	public void MoveToLastScene () {		
		currentScene--;
		MoveMainCameraToCurrentScene ();
	}

	public void ToggleTextDisplay () {
		textDisplay.gameObject.SetActive (!textDisplay.gameObject.activeInHierarchy);	
	}

	void Awake () {
		MakeInstance ();
		InitScenes ();
		InitSceneAssets ();
		InitUi ();
	}

	void Start () {
		MoveMainCameraToCurrentScene ();
	}

	private void MakeInstance () {
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad(instance);
		}
	}

	private void InitScenes () {		
		currentScene = 0;
		maxScene = sceneCameras.Length - 1;
	}

	private void InitSceneAssets () {

		sceneSpecificAssets = new Dictionary<int, GameObject[]>();
		for (int tagIndex = 0; tagIndex <= maxScene; tagIndex ++) {
		
			sceneSpecificAssets.Add(tagIndex, GameObject.FindGameObjectsWithTag("Scene"+tagIndex));
		}
	}

	private void InitUi () {
		buttonLeft = GameObject.FindGameObjectWithTag ("ButtonLeft").GetComponent<Button> ();
		buttonRight = GameObject.FindGameObjectWithTag ("ButtonRight").GetComponent<Button> ();
		fadingAnimator = GameObject.FindGameObjectWithTag ("SceneFader").GetComponent<Animator> ();
		textDisplay = GameObject.FindGameObjectWithTag ("TextDisplay").GetComponent<Image> ();

		textDisplay.gameObject.SetActive(false);
	}

	private void ActivateCurrentSceneAssets () {
	
		for (int tagIndex = 0; tagIndex <= maxScene; tagIndex ++) {

			for (int assetIndex = 0; assetIndex < sceneSpecificAssets[tagIndex].Length; assetIndex ++) {
				sceneSpecificAssets[tagIndex][assetIndex].SetActive(tagIndex == currentScene);
			}
		}
	}

	private void MoveMainCameraToCurrentScene () {
		
		fadingAnimator.SetTrigger ("FadeIn");
		DisableBoundaryButtons ();
	}

	private void DisableBoundaryButtons () {

		buttonRight.interactable = !IsCurrentSceneOutOfUpperBound ();
		buttonLeft.interactable = !IsCurrentSceneOutOfLowerBound ();
	}

	private bool IsCurrentSceneOutOfUpperBound () {
		return currentScene >= maxScene;
	}

	private bool IsCurrentSceneOutOfLowerBound () {
		return currentScene <= 0;
	}

	private void UpdateTextToCurrentScene () {
		textDisplay.gameObject.SetActive (true);
		textDisplay.sprite = texts [currentScene];
	}

}
