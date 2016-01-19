using UnityEngine;
using System.Collections;

public class PanelCamerasController : MonoBehaviour {

	[SerializeField]
	private Camera[] panelCameras;

	public int GetTotalNumberOfPanels () {
	
		return panelCameras.Length;
	}

	public void JumpToCurrentCamera (int currentPanel) {

		Camera.main.gameObject.SetActive (false);
		panelCameras [currentPanel].gameObject.SetActive(true);
	}


}
