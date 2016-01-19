using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelUiController : MonoBehaviour {

	
	[SerializeField]
	private Sprite[] captions;
	
	private Button buttonLeft;
	private Button buttonRight;
	private Animator fadingAnimator;
	private Image captionDisplay;

	private int totalNumberOfPanels;
	private int currentPanel;

	void Awake () {
		InitUi ();
	}

	public void Init (int totalNumberOfPanels) {
		this.totalNumberOfPanels = totalNumberOfPanels;
	}
	
	public void ToggleTextDisplay () {
		captionDisplay.gameObject.SetActive (!captionDisplay.gameObject.activeInHierarchy);	
	}

	public void StartPanelSwitch (int nextPanel) {

		currentPanel = nextPanel;

		ActivateFading ();
		DisableBoundaryButtons ();
	}

	public void UpdateCaptionForCurrentPanel () {

		if (captions.Length - 1 < currentPanel) {
			Debug.Log ("Panel " + currentPanel + " has no caption assigned.");
		}

		captionDisplay.gameObject.SetActive (true);
		captionDisplay.sprite = captions [currentPanel];
	}
		
	private void InitUi () {
		buttonLeft = GameObject.FindGameObjectWithTag ("ButtonLeft").GetComponent<Button> ();
		buttonRight = GameObject.FindGameObjectWithTag ("ButtonRight").GetComponent<Button> ();
		fadingAnimator = GameObject.FindGameObjectWithTag ("SceneFader").GetComponent<Animator> ();
		captionDisplay = GameObject.FindGameObjectWithTag ("TextDisplay").GetComponent<Image> ();
		
		captionDisplay.gameObject.SetActive(false);
	}

	private void ActivateFading () {
		fadingAnimator.SetTrigger ("FadeIn");
	}
	
	private void DisableBoundaryButtons () {
		
		buttonRight.interactable = !IsCurrentSceneOutOfUpperBound ();
		buttonLeft.interactable = !IsCurrentSceneOutOfLowerBound ();
	}
	
	private bool IsCurrentSceneOutOfUpperBound () {
		return currentPanel >= totalNumberOfPanels-1;
	}
	
	private bool IsCurrentSceneOutOfLowerBound () {
		return currentPanel <= 0;
	}

}
