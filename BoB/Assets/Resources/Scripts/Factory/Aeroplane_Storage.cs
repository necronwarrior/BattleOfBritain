using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aeroplane_Storage : MonoBehaviour {

	public List<GameObject> Aerolist; // List of Aeroplanes in current airport
	private GameObject Aeroplane1;
	// Use this for initialization
	void Start () {
		 //Initilisation of list
		Aeroplane1 = (GameObject)Resources.Load("/Aeroplanes/spitfire");//temp load plane
		DeployAeroplane ();//test deploy
	}

	public void DeployAeroplane() {
		Aerolist.Add (Aeroplane1);//increase the list of stored aeroplanes
		bool tooty;
		tooty = false;
		//SendEmail ();
	}

	void SendEmail ()
	{
		string email = "necron_warrior@hotmail.co.uk";
		string subject = MyEscapeURL("My Subject");
		string body = MyEscapeURL("My Body\r\nFull of non-escaped chars");
		Application.OpenURL("mailto:" + email + "?subject=" + subject + "&body=" + body);
	}
	string MyEscapeURL (string url)
	{
		return WWW.EscapeURL(url).Replace("+","%20");
	}
}
