using UnityEngine;
using System;
using System.IO;
using System.Xml;
using System.Text;
using SimpleJSON;



using System.Collections;

public class CameraPick : MonoBehaviour {
	
	string lastPick = "Click to select tract";
	string lastPick_1 = "";
	string lastPick_2 = "";
	string lastPick_3 = "";
	
	Material highlightMaterial;
	
	GameObject lastObject;
	Material lastMaterial;
	
	// Use this for initialization
	void Start () {
	
		highlightMaterial = Resources.Load("highlightMaterial", typeof(Material)) as Material;

	}
	
	void Update()
	{			
	    if (Input.GetButtonDown("ps3x") || Input.GetMouseButtonDown(0) )
	    {
	       Debug.Log("Mouse is down");
	 
	       RaycastHit hitInfo = new RaycastHit();
			
	       bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
			
			
			Debug.Log (hitInfo);
			
	       if (hit) 
	       {
	         //Debug.Log("Hit " + hitInfo.transform.gameObject.name);
	         if (hitInfo.transform.gameObject.tag == "Construction")
	         {
	          //Debug.Log ("It's working!");
	         } else {
	          //ebug.Log ("nopz");
					
				if(this.lastObject != null && this.lastMaterial != null)
				{
					this.lastObject.renderer.material = this.lastMaterial;	
				}
						
					
				string experiment_id = hitInfo.transform.gameObject.name.Split('-')[0];
					
				
					
				this.lastObject = hitInfo.transform.gameObject;  
				//this.lastObject = GameObject.Find(experiment_id + "-0000");
					
				
					
					
					
				this.lastMaterial = hitInfo.transform.gameObject.renderer.material;
						
				hitInfo.transform.gameObject.renderer.material = highlightMaterial;
				
				this.lastPick = experiment_id;
					
				Download("http://api.brain-map.org/api/v2/data/query.json?criteria=model::SectionDataSet,rma::criteria,[id$eq" + experiment_id +  "],products,rma::include,specimen(injections(primary_injection_structure,structure),structure)");
					
	         }
	       } else {
	         //Debug.Log("No hit");
				
				if(this.lastObject != null)
				{
					
					this.lastObject.renderer.material = this.lastMaterial;	
				}
				
				this.lastObject = null;
				this.lastMaterial = null;
				
				this.lastPick = "Nothing selected";
				this.lastPick_1 = "";
				this.lastPick_2 = "";
				this.lastPick_3 = "";
	       }
			
	      // Debug.Log("Mouse is down");
	    } 
//		else if( Input.GetMouseButtonDown(0) )
//		{
//			Debug.Log("PS3 x is down");
//	 
//	       RaycastHit hitInfo = new RaycastHit();
//			
//			
//			//Vector3 mid = new Vector3(0.5f, 0.5f, 0.0f);
//			
//			
//	       bool hit = Physics.Raycast(Camera.main.ViewportPointToRay(mid), out hitInfo);
//			
//			
//			Debug.Log (hitInfo);
//			
//	       if (hit) 
//	       {
//	         //Debug.Log("Hit " + hitInfo.transform.gameObject.name);
//	         if (hitInfo.transform.gameObject.tag == "Construction")
//	         {
//	          //Debug.Log ("It's working!");
//	         } else {
//	          //ebug.Log ("nopz");
//					
//				if(this.lastObject != null && this.lastMaterial != null)
//				{
//					this.lastObject.renderer.material = this.lastMaterial;	
//				}
//						
//					
//				string experiment_id = hitInfo.transform.gameObject.name.Split('-')[0];
//					
//				
//					
//				this.lastObject = hitInfo.transform.gameObject;  
//				//this.lastObject = GameObject.Find(experiment_id + "-0000");
//					
//				this.lastMaterial = hitInfo.transform.gameObject.renderer.material;
//						
//				hitInfo.transform.gameObject.renderer.material = highlightMaterial;
//				
//				this.lastPick = experiment_id;
//					
//				Download("http://api.brain-map.org/api/v2/data/query.json?criteria=model::SectionDataSet,rma::criteria,[id$eq" + experiment_id +  "],products,rma::include,specimen(injections(primary_injection_structure,structure),structure)");
//					
//	         }
//	       } else {
//	         //Debug.Log("No hit");
//				
//				if(this.lastObject != null)
//				{
//					
//					this.lastObject.renderer.material = this.lastMaterial;	
//				}
//				
//				this.lastObject = null;
//				this.lastMaterial = null;
//				
//				this.lastPick = "Nothing selected";
//				this.lastPick_1 = "";
//				this.lastPick_2 = "";
//				this.lastPick_3 = "";
//	       }
//			
//			
//			 //
//		}
	}
	
	
	
	void Download (string url) {
		
	     StartCoroutine(FinishDownload(url));
	     //In C#, you have to explicitly start a corotine.
	}
	 
	IEnumerator FinishDownload (string url) {
	     WWW hs_get = new WWW(url);
	 
	    yield return hs_get;
		
		var N = JSON.Parse(hs_get.text);
		
		Debug.Log (hs_get.text);

		this.lastPick_1 = N["msg"][0]["specimen"]["injections"][0]["structure"]["acronym"].ToString();
		
		this.lastPick_2 = N["msg"][0]["specimen"]["injections"][0]["structure"]["name"].ToString();
		
		//this.lastPick_3 = "";
//		string val = N["data"]["sampleArray"][0];      // val contains "string value"
		
		
		Debug.Log (this.lastPick_2.ToString());
	    //Work with the retrieved info.
	}
	
	public ArrayList GetTextFromSomewhere()
	{
		ArrayList a = new ArrayList();
		a.Add(this.lastPick);
		a.Add(this.lastPick_1);
		a.Add(this.lastPick_2);
		
		return a;
	}
}



 
//
//public function getXMLdata () 
//
//{
//
//  var i;
//
//	Debug.Log("getting...");
//
//	var url = "http://myserver/myscript";
//
//  // Start a download of the given URL
//
//	Debug.Log("...from "+url);
//
//  	var www : WWW = new WWW (url);
//
//	Debug.Log("yielding");
//
// 	 // Wait for download to complete
//
//  	yield www;
//
//	Debug.Log("yielded");
//
// 
//
//  	var xml = new XmlDocument();
//
//  	xml.LoadXml([url]www.data[/url]);
//
//    
//
//  	var wrapperNode = xml.LastChild;
//
//  	if (wrapperNode.Name != "wrapper")
//
//  	{
//
//    	Debug.LogError("This is not a wrapper file");
//
//  	}
//
//	Debug.Log("got data");
//
//}

///* Example XML:
//
//<wrapper>
//
// <myData address="123 Main St." desc="Casa de Joe Shmoe">
//
//  <income>0</income> 
//
//  <bday>Jun 09,1910</bday> 
//
// </myData>
//
//</wrapper>
//
//*/
//
//  var cnodeCount = wrapperNode.ChildNodes.Count;
//
//Debug.Log("got " +cnodeCount);
//
//  for (i = 0; i < cnodeCount; i++)
//
//  {
//
//    var dataNode = wrapperNode.ChildNodes.Item(i);
//
//    var address = dataNode.Attributes["address"].Value;
//
//    var desc = dataNode.Attributes["desc"].Value;
//
//    var cCount = dataNode.ChildNodes.Count;
//
//    var income = "";
//
//    var bday = "";
//
//    for (var j = 0; j < cCount; j++)
//
//    {
//
//      if (dataNode.ChildNodes.Item(j).Name == "income")
//
//        income = dataNode.ChildNodes.Item(j).InnerText;
//
//      else if (dataNode.ChildNodes.Item(j).Name == "bday")
//
//        bday = dataNode.ChildNodes.Item(j).InnerText;
//
//    }
//
//// Now do something useful with this data
//
//  }
//
//}