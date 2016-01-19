using UnityEngine;
using System.Collections;

public class PanelCamerasController : MonoBehaviour {

	[SerializeField]
	private Camera[] panelCameras;
	private int totalNumberOfPanels = -1;

	public int GetTotalNumberOfPanels () {
	
		if (totalNumberOfPanels == -1) {
			totalNumberOfPanels = panelCameras.Length-1;
		}

		return totalNumberOfPanels;
	}

	public void JumpToCurrentCamera (int currentPanel) {

		Camera.main.gameObject.SetActive (false);
		panelCameras [currentPanel].gameObject.SetActive(true);
	}


}
