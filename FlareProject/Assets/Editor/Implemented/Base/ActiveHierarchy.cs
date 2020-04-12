using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/**HierarchyのObjectにToggleを生成しONOFFでActiveを切り替える**/

public static class ActiveHierarchy
{
	//Toggleの横幅
	private const int WIDTH = 16;

	[InitializeOnLoadMethod]
	private static void Initialize ()
	{
		//HierarchyのGUIに処理を渡す
		EditorApplication.hierarchyWindowItemOnGUI += HierarchyOnGUI;
	}

	private static void HierarchyOnGUI (int instanceID, Rect selectionRect)
	{
		//選択しているObject
		var go = EditorUtility.InstanceIDToObject (instanceID) as GameObject;

		if (go == null) { return; }

		//Toggleの位置の情報
		var pos = selectionRect;
		//表示の調整
		pos.x = pos.xMax - WIDTH;
		//判定の幅
		pos.width = WIDTH;

		//Toggleの表示
		var newActive = GUI.Toggle (pos, go.activeSelf, string.Empty);

		if (newActive == go.activeSelf)
		{
			return;
		}
		//Activeの反映
		go.SetActive (newActive);
	}
}
