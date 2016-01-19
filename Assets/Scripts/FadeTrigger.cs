using UnityEngine;
using System.Collections;

public class FadeTrigger : MonoBehaviour {

	public void MoveCameraToNextPosition () {
		PanelTransitionController.instance.MoveCameraToNextPosition ();
	}
}
