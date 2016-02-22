using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;



public class LoginAndRegister : MonoBehaviour {

	public UIInput inputRegisterUsername ;
	public UIInput inputRegisterEmail ;
	public UIInput inputRegisterPassword ;

	public UIInput inputLogIn_Username ;
	public UIInput inputLogIn_Password ;

	public UILabel labelErrorRegister;
	public UILabel labelErrorLogin;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Register()
	{
		var request = new RegisterPlayFabUserRequest()
		{
			TitleId = PlayFabSettings.TitleId,
			Username = inputRegisterUsername.value,
			Password = inputRegisterPassword.value,
			Email = inputRegisterEmail.value
		};
		PlayFabClientAPI.RegisterPlayFabUser(request, (result) =>
			{
				LoginRegisterSuccess(result.PlayFabId,result.SessionTicket);
			}, (error) =>
			{
				labelErrorRegister.text = error.ErrorMessage;
//				RegErrorText.gameObject.transform.parent.gameObject.SetActive(true);
//				PlayFabErrorHandler.HandlePlayFabError(error);
			});
	
	
	}

	private void LoginRegisterSuccess(string PlayFabId, string SessionTicket)
	{
//		PlayFabDataStore.PlayFabId = PlayFabId;
//		PlayFabDataStore.SessionTicket = SessionTicket;
		labelErrorRegister.text = "Register Successs";
//		LoginErrorText.gameObject.transform.parent.gameObject.SetActive(false);
//		RegErrorText.gameObject.transform.parent.gameObject.SetActive(false);

//		GetDataFromPlayFab(() =>
//			{
////				GUI_Manager.instance.OnEnableStore();
////				WindowManager.SendEvent("Store");
//			});
	}

	private void GetDataFromPlayFab(Action callback)
	{
		
		var catalogRequest = new GetCatalogItemsRequest()
		{
			CatalogVersion = "ItemCatalog"
		};
		PlayFabClientAPI.GetCatalogItems(catalogRequest, (catResult) =>
			{
//				PlayFabDataStore.Catalog = catResult.Catalog;

				var storeRequest = new GetStoreItemsRequest()
				{
//					CatalogVersion = "ItemCatalog",
					StoreId = "ResizerItems"
				};
				PlayFabClientAPI.GetStoreItems(storeRequest, (storeResult) =>
					{
//						PlayFabDataStore.Store = storeResult.Store;
						callback();

//						GUI_Manager.instance.OnEnableStore();
					}, (error) => {});

			}, (error) => {});

//		CharacterData characterData = GetComponent<CharacterData> ();
		var playerdataRequest = new GetUserDataRequest() {
//			PlayFabId = PlayFabId,
			Keys = null 
		};
		PlayFabClientAPI.GetUserData(playerdataRequest,(result) =>
		{
				Debug.Log("data" + playerdataRequest.PlayFabId);		
			},(error) => {});

		var playerdatatest = new GetCharacterDataResult ();
//		Debug.Log("data111" + playerdatatest.P);

	}

	public void Login()
	{
		
		var loginRequest = new LoginWithPlayFabRequest()
		{
			TitleId = GameInstance.instance.TitleID,
			Username = inputLogIn_Username.text, 
			Password = inputLogIn_Password.text
				
		};
		PlayFabClientAPI.LoginWithPlayFab(loginRequest, (result) =>
			{
				CharacterData characterdata = GetComponent<CharacterData>();
				characterdata.playfabsID = result.PlayFabId ;
				DataPlayer.dataPlayer = loginRequest.Username;
				OnLoginSuccess(result.PlayFabId, result.SessionTicket);
			}, (error) =>
			{
				labelErrorLogin.text = error.ErrorMessage;
//				LoginErrorText.gameObject.transform.parent.gameObject.SetActive(true);
//				PlayFabErrorHandler.HandlePlayFabError(error);
			});
		
	
	}

//	public void LoginCustom(){
//		Loginwith request = new LoginWithCustomIDRequest () 
//		{
//			TitleId = PlayFabSettings.TitleId,
//			CreateAccount = true,
//			CustomId = SystemInfo.deviceUniqueIdentifier
//
//		};
//
//		PlayFabClientAPI.LoginWithCustomID (request, (result) => {
//			CharacterData characterdata = GetComponent<CharacterData>();
//			characterdata.playfabsID = result.PlayFabId ;
//			Debug.Log("Playfabs " + characterdata.playfabsID);
//			if(result.NewlyCreated)
//			{
//				Debug.Log("(new account)");
//			}
//			else
//			{
//				Debug.Log("(existing account)");
//			}
//		}, (error) => {
//
//			
//		});
//	}


	void OnLoginSuccess(string PlayFabId, string SessionTicket)
	{
//		PlayFabDataStore.PlayFabId = PlayFabId;
//		PlayFabDataStore.SessionTicket = SessionTicket;
//		GetPhotonAuthenticationenRequest request = new GetPhotonAuthenticationTokenRequest ();

//		request.PhotonApplicationId = GameInstance.instance.AppID.Trim ();

//		PlayFabClientAPI.GetPhotonAuthenticationToken
		labelErrorLogin.text = "Login Successs";
		SceneManager.LoadScene ("MultiplayerDemo");
//		GetDataFromPlayFab(() =>
//		{
//				//						GUI_Manager.instance.OnEnableStore();
//				//				WindowManager.SendEvent("Store");
//		});	
	}

	void OnPhptonAuthenticationSuccess(GetPhotonAuthenticationTokenResult result){
		
	}

}
