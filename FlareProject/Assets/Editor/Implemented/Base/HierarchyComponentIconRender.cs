using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

/// <summary>
/// hierarchyにコンポーネントのアイコンを表示
/// </summary>
public static class HierarchyComponentIconRender
{
	private const int WIDTH = 16;
	private const int HEIGHT = 16;

	[InitializeOnLoadMethod]
	private static void Example ()
	{
		EditorApplication.hierarchyWindowItemOnGUI += OnGUI;
	}

	private static void OnGUI (int instanceID, Rect selectionRect)
	{
		GameObject go = EditorUtility.InstanceIDToObject (instanceID) as GameObject;

		if (go == null)
		{
			return;
		}

		Rect pos = selectionRect;
		pos.x = pos.xMax - WIDTH - 16;
		pos.width = WIDTH;
		pos.height = HEIGHT;

		var components = go.GetComponents<Component> ().Where (c => c != null).Where (c => !(c is Transform)).Reverse ();

		var current = Event.current;

		foreach (var c in components)
		{
			Texture image = null;
			image = AssetPreview.GetMiniThumbnail (c);
			GUI.DrawTexture (pos, image, ScaleMode.ScaleToFit);
			pos.x -= pos.width;
		}
	}
}
