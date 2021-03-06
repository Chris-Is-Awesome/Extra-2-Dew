﻿using System;
using UnityEngine;
using ModStuff;

public class LudositySplash : MonoBehaviour
{
	[SerializeField]
	string sceneToLoad = string.Empty;

	[SerializeField]
	float _time = 5f;

	[SerializeField]
	GameObject _layout;

	GuiWindow mainWnd;

	float timer;

	void Start()
	{
		// Enable Unity debug logging
		DebugManager.EnableDebugging();

		// TEMP
		Utility.LoadLevel("MainMenu");

		GuiBindInData guiBindInData = new GuiBindInData(null, null);
		guiBindInData.Content.SetValue("gameLoading", false);
		MainMenu.ApplyUIData(PlatformInfo.Current.GetDataForUI("splash"), guiBindInData.Content);
		GuiBindData guiBindData = GuiNode.Connect(this._layout, guiBindInData);
		this.mainWnd = guiBindData.GetTracker<GuiWindow>("startRoot");
		this.mainWnd.Show(null, null);
		this.timer = this._time;
	}

	void Update()
	{
		this.timer -= Time.deltaTime;
		if (this.timer <= 0f)
		{
			if (string.IsNullOrEmpty(this.sceneToLoad))
			{
				Utility.LoadLevel(1);
			}
			else
			{
				Utility.LoadLevel(this.sceneToLoad);
			}
		}
	}
}
