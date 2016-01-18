using UnityEngine;
using System.Collections;

public class FadeTrigger : MonoBehaviour {

	public void MoveCameraToNextPosition () {
		SceneCameraPositions.instance.MoveCameraToNextPosition ();
	}
}
