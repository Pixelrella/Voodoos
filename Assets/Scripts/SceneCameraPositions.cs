using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof (PanelAssetsContoller))]
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

	private int currentPanel;
	private int totalNumberOfPanels;

	private PanelAssetsContoller panelAssetController;
		

	public void MoveCameraToNextPosition () {

		ActivateCurrentPanelAssets ();
		JumpToCurrentCamera ();
		UpdateTextToCurrentScene ();
	}

	private void ActivateCurrentPanelAssets () {
		panelAssetController.ActivateCurrentPanelAssets (currentPanel);
	}

	private void JumpToCurrentCamera () {
		for (int i = 0; i < sceneCameras.Length; i++) {
			sceneCameras [i].gameObject.SetActive(currentPanel == i);
		}
	}

	public void MoveToNextScene () {		
		currentPanel ++;
		MoveMainCameraToCurrentScene ();
	}
	
	public void MoveToLastScene () {		
		currentPanel--;
		MoveMainCameraToCurrentScene ();
	}

	public void ToggleTextDisplay () {
		textDisplay.gameObject.SetActive (!textDisplay.gameObject.activeInHierarchy);	
	}

	void Awake () {
		MakeInstance ();
		InitPanels ();
		InitPanelAssets ();
		InitUi ();
	}

	private void MakeInstance () {
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad(instance);
		}
	}

	private void InitPanels () {		
		currentPanel = 0;
		totalNumberOfPanels = sceneCameras.Length - 1;
	}

	private void InitPanelAssets () {
		panelAssetController = GetComponent<PanelAssetsContoller> ();
		panelAssetController.InitPanelAssets (totalNumberOfPanels);
	}

	private void InitUi () {
		buttonLeft = GameObject.FindGameObjectWithTag ("ButtonLeft").GetComponent<Button> ();
		buttonRight = GameObject.FindGameObjectWithTag ("ButtonRight").GetComponent<Button> ();
		fadingAnimator = GameObject.FindGameObjectWithTag ("SceneFader").GetComponent<Animator> ();
		textDisplay = GameObject.FindGameObjectWithTag ("TextDisplay").GetComponent<Image> ();

		textDisplay.gameObject.SetActive(false);
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
		return currentPanel >= totalNumberOfPanels;
	}

	private bool IsCurrentSceneOutOfLowerBound () {
		return currentPanel <= 0;
	}

	private void UpdateTextToCurrentScene () {
		textDisplay.gameObject.SetActive (true);
		textDisplay.sprite = texts [currentPanel];
	}

}
