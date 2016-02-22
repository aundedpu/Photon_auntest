using UnityEngine;
using System.Collections;

public class GUI_Manager : MonoBehaviour {

	public static GUI_Manager instance;
	public  UIPanel registerpanel ;
	public UIPanel loginpanel;
	public UIPanel storepanel;

	public UIGrid gridPanel;
	public GameObject itemStorePrefab;
	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnEnableStore(){
		registerpanel.gameObject.SetActive (false);
		loginpanel.gameObject.SetActive (false);
		storepanel.gameObject.SetActive (true);
		int i = 1;
		uint indext = 0 ;
//		foreach (var item in PlayFabDataStore.Store) {
//			var catItem = PlayFabDataStore.Catalog.Find((ci) => { return ci.ItemId == item.ItemId; });
//			GameObject go_store = (GameObject)Instantiate (itemStorePrefab) ;
//			gridPanel.AddChild (go_store.transform);
//			go_store.name = "item " + i;
//			i++;
//			go_store.transform.localScale = new Vector3 (1f, 1f, 1f);
//			go_store.GetComponent<ItemStore> ().displayName.text = catItem.DisplayName;
//			go_store.GetComponent<ItemStore> ().description.text = catItem.Description;
//			go_store.GetComponent<ItemStore> ().cost.text = string.Format("cost : {0} ",catItem.VirtualCurrencyPrices ["GO"]);
//			indext++;
//			if (catItem == null){ continue; }
//					Debug.Log (""+catItem.DisplayName);
//					Debug.Log (""+catItem.Description);
//		}
	}
}
