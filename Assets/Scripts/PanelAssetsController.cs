using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PanelAssetsController : MonoBehaviour {


	[SerializeField]
	private string tagPrefix = "Panel";

	private Dictionary<int, GameObject[]> panelSpecificAssets;
	private int totalNumberOfPanels;

	public void InitPanelAssets (int totalNumberOfPanels) {

		InitClassVariables (totalNumberOfPanels);
		StoreSpecificAssetsForAllPanels ();
	}

	private void InitClassVariables (int totalNumberOfPanels) {

		this.totalNumberOfPanels = totalNumberOfPanels;
		panelSpecificAssets = new Dictionary<int, GameObject[]>();
	}

	private void StoreSpecificAssetsForAllPanels () {

		for (int tagIndex = 0; tagIndex <= totalNumberOfPanels; tagIndex ++) {

			panelSpecificAssets.Add(tagIndex, GameObject.FindGameObjectsWithTag (tagPrefix + tagIndex));
		}
	}

	public void ActivateCurrentPanelAssets (int currentPanel) {
		
		for (int tagIndex = 0; tagIndex <= totalNumberOfPanels; tagIndex ++) {
			
			for (int assetIndex = 0; assetIndex < panelSpecificAssets[tagIndex].Length; assetIndex ++) {
				panelSpecificAssets[tagIndex][assetIndex].SetActive(tagIndex == currentPanel);
			}
		}
	}
}
