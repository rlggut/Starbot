using UnityEngine;
using System.Collections;

public class Nums : MonoBehaviour {
	public string name;
	public int dec;
	public GameObject t0,t1,t2,t3,t4,t5,t6,t7,t8,t9;

	private int time;
	// Use this for initialization
	void Start () {
	
	}
	void nil()
	{
		t0.SetActive(false);t1.SetActive(false);t2.SetActive(false);t3.SetActive(false);t4.SetActive(false);t5.SetActive(false);
		t6.SetActive(false);t7.SetActive(false);t8.SetActive(false);t9.SetActive(false);
	}
	// Update is called once per frame
	void Update () {
		time=PlayerPrefs.GetInt(name);
		if(dec==2) time=(time-time%60)/60;
		if(dec==1) time=(time%60-(time%60)%10)/10;
		if(dec==0) time=time%10;

		nil ();
		if(time==0) t0.SetActive(true);
		if(time==1) t1.SetActive(true);
		if(time==2) t2.SetActive(true);
		if(time==3) t3.SetActive(true);
		if(time==4) t4.SetActive(true);
		if(time==5) t5.SetActive(true);
		if(time==6) t6.SetActive(true);
		if(time==7) t7.SetActive(true);
		if(time==8) t8.SetActive(true);
		if(time==9) t9.SetActive(true);
	}
}