using UnityEngine;
using System.Collections;

public class Batery : MonoBehaviour {

	public GameObject las_an,las,bater;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "bat") {
			PlayerPrefs.SetInt ("win",1);
			bater.SetActive(false);
			las_an.SetActive(true);
			las.SetActive(false);
		}
	}
}