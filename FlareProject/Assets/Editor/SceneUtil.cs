using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;

public class SceneUtil
{
	[MenuItem ("SceneUtil/Main %#m")]
	static private void SceneMain ()
	{
		Debug.Log ("メインシーンへ移動");
		EditorSceneManager.OpenScene (string.Format ("{0}{1}", Application.dataPath, "/Scenes/Main.unity"));
	}

	[MenuItem ("SceneUtil/Create")]
	static private void SceneCreate ()
	{
		Debug.Log ("シーン作成");
		Scene scene = EditorSceneManager.NewScene (NewSceneSetup.DefaultGameObjects);
		EditorSceneManager.SaveScene (scene);//, string.Format ("{0}{1}", Application.dataPath, "/Scenes/NewScene.unity"));
	}
}
