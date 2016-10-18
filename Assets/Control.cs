using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {
	public GameObject lp_left,lp_right,bot,planet;
	public string s;
	public float x_old,xr,xl,xr1,xl1;
	private float y,yr,yl,yl1,yr1;
	private int time,t,win,lose;

	// Use this for initialization
	void Start () {
		win = 0;
		lose = 0;
		PlayerPrefs.SetInt ("win",0);
		PlayerPrefs.SetInt ("lose",0);
		yl = 0;
		yr = 0;
		time = System.DateTime.Now.Hour * 3600 + System.DateTime.Now.Minute * 60 + System.DateTime.Now.Second;
	}
	
	// Update is called once per frame
	void Update () {
		win = PlayerPrefs.GetInt ("win");
		lose = PlayerPrefs.GetInt ("lose");

		t = System.DateTime.Now.Hour * 3600 + System.DateTime.Now.Minute * 60 + System.DateTime.Now.Second;
		if((win+lose)==0) PlayerPrefs.SetInt("time",480-(t-time));
		if((480-(t-time))==0) PlayerPrefs.SetInt ("lose",1);

		y=bot.transform.eulerAngles.y*(Mathf.PI/180);
		yr1 = (yr + Input.GetAxis ("Hor2_j"));
		if(yr1<0) yr1=yr1+360.0f;
		//ограничения на левую руку
		if (((yr1 >= 352.0f)&&(yr1 <= 360.0f))||
		      ((yr1 >= 0.0f)&&(yr1 <= 19.0f)))
		{
			lp_right.transform.Rotate (0, Input.GetAxis ("Hor2_j"), 0);
			yr += Input.GetAxis ("Hor2_j");
		}

		xr1 = (xr + Input.GetAxis ("Vert2_j"));
		if(xr1<0) xr1=xr1+360.0f;
		//ограничения на левую руку
		if (((xr1 >= 345.0f)&&(xr1 <= 360.0f))||
		    ((xr1 >= 0.0f)&&(xr1 <= 14.0f)))
		{
			lp_right.transform.Rotate (Input.GetAxis ("Vert2_j"),0, 0);
			xr += Input.GetAxis ("Vert2_j");
		}

//		lp_left.transform.Rotate (Input.GetAxis ("Vert2_j"), Input.GetAxis ("Hor2_j"), 0);
//		lp_right.transform.Rotate (Input.GetAxis ("Vert_j"), Input.GetAxis ("Hor_j"), 0);

		//ограничения на правую руку
		yl1 = (yl + Input.GetAxis ("Hor_j"));
		if(yl1<0) yl1=yl1+360.0f;
		if (((yl1 > 341.0f)&&(yl1 < 360.0f))||
		    ((yl1 > 0.0f)&&(yl1 < 7.0f)))
		{
			lp_left.transform.Rotate (0, Input.GetAxis ("Hor_j"), 0);
			yl += Input.GetAxis ("Hor_j");
		}

		xl1 = (xl + Input.GetAxis ("Vert_j"));
		if(xl1<0) xl1=xl1+360.0f;
		if (((xl1 > 345.0f)&&(xl1 < 360.0f))||
		    ((xl1 > 0.0f)&&(xl1 < 14.0f)))
		{
			lp_left.transform.Rotate (Input.GetAxis ("Vert_j"),0, 0);
			xl += Input.GetAxis ("Vert_j");
		}

		if(Input.GetKey(KeyCode.JoystickButton4)||Input.GetKey(KeyCode.JoystickButton0))
		{
			s="Go_to";
			bot.GetComponent<Rigidbody>().AddForce(new Vector3(Mathf.Cos(y),0,-Mathf.Sin(y))*15);
		}
		if(Input.GetKey(KeyCode.JoystickButton5)||Input.GetKey(KeyCode.JoystickButton2))
		{
			s="Go_back";
			bot.GetComponent<Rigidbody>().AddForce(-new Vector3(Mathf.Cos(y),0,-Mathf.Sin(y))*15);
		}
		if(Input.GetKey(KeyCode.JoystickButton6)||Input.GetKey(KeyCode.JoystickButton3))
		{
			s="Turn_left";
			bot.transform.Rotate(0,-0.5f,0);
		}
		if(Input.GetKey(KeyCode.JoystickButton7)||Input.GetKey(KeyCode.JoystickButton1))
		{
			s="Turn_right";
			bot.transform.Rotate(0,0.5f,0);
		}
		if(Input.GetKey(KeyCode.JoystickButton9)) Application.LoadLevel("help");
/*		if(Input.GetKey(KeyCode.JoystickButton10)) s="but10";
		if(Input.GetKey(KeyCode.JoystickButton11)) s="but11";
		if(Input.GetKey(KeyCode.JoystickButton12)) s="but12";
		if(Input.GetKey(KeyCode.JoystickButton13)) s="but13";
		if(Input.GetKey(KeyCode.JoystickButton14)) s="but14";
		if(Input.GetKey(KeyCode.JoystickButton15)) s="but15";
		if(Input.GetKey(KeyCode.JoystickButton16)) s="but16";
		if(Input.GetKey(KeyCode.JoystickButton17)) s="but17";
		if(Input.GetKey(KeyCode.JoystickButton18)) s="but18";
		if(Input.GetKey(KeyCode.JoystickButton19)) s="but19";*/

		if(lose==1)
		{
			planet.SetActive(true);
			if(480-(t-time)==-10) Application.LoadLevel("help");
		}
	}
}