using UnityEngine;
using System.Collections;

[RequireComponent (typeof (PanelAssetsController))]
[RequireComponent (typeof (PanelCamerasController))]
public class PanelTransitionController : MonoBehaviour {

	public static PanelTransitionController instance;

	private int currentPanel;
	private int totalNumberOfPanels;

	private PanelAssetsController panelAssetController;
	private PanelCamerasController panelCamerasController;
	private PanelUiController panelUiController;
		

	void Awake () {
		MakeInstance ();
		InitPanels ();
		InitUi ();
	}

	public void MoveCameraToNextPosition () {

		ActivateCurrentPanelAssets ();
		JumpToCurrentCamera ();
		UpdateCaptionForCurrentPanel ();
	}

	private void ActivateCurrentPanelAssets () {
		panelAssetController.ActivateCurrentPanelAssets (currentPanel);
	}

	private void JumpToCurrentCamera () {

		panelCamerasController.JumpToCurrentCamera (currentPanel);
	}

	private void UpdateCaptionForCurrentPanel () {

		panelUiController.UpdateCaptionForCurrentPanel ();
	}

	public void MoveToNextScene () {		
		currentPanel ++;
		MoveMainCameraToCurrentScene ();
	}
	
	public void MoveToLastScene () {	
		currentPanel--;
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

	private void InitPanels () {		

		InitPanelCameras ();
		InitPanelAssets ();

		currentPanel = -1;
		totalNumberOfPanels = panelCamerasController.GetTotalNumberOfPanels ();

		Debug.Log ("totalNumberOfPanels: " + totalNumberOfPanels);
	}

	private void InitPanelCameras () {	
		panelCamerasController = GetComponent<PanelCamerasController> ();
	}

	private void InitPanelAssets () {
		panelAssetController = GetComponent<PanelAssetsController> ();
		panelAssetController.InitPanelAssets (totalNumberOfPanels);
	}

	private void InitUi () {
		panelUiController = GetComponent<PanelUiController> ();
		panelUiController.Init (totalNumberOfPanels);
	}

	private void MoveMainCameraToCurrentScene () {
		
		panelUiController.StartPanelSwitch (currentPanel);
	}
}
