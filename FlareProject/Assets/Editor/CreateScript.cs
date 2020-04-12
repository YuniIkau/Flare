using System.IO;
using System.Reflection;
using System.Text;
using UnityEditor;
using UnityEngine;

/**メニュー又はAlt+Sでテンプレートスクリプトの生成**/

public class CreateScript : EditorWindow
{
	//生成するフォルダの指定
	static string defaultTemplatePath = "Assets/Reference/DefaultTemplate.txt";
	static string customTemplatePath = "Assets/Reference/CustomTemplate.txt";
	static string managerTemplatePath = "Assets/Reference/ManagerTemplate.txt";
	static string selectTemplatePath = "";
	//生成するスクリプトのデフォルトの名前
	static string scriptName = "NewScript";

	int selected;
	static string fullPath = "";
	static string scriptText = "";
	static GUIStyle style = new GUIStyle (GUI.skin.label);

	[MenuItem ("Assets/Create/CreateTemplateScript &s", false, 0)]
	static public void Open ()
	{
		var window = GetWindow<CreateScript> (true, "CreateScript");
		window.maxSize = window.minSize = new Vector2 (400, 300);
	}

	private void OnGUI ()
	{
		EditorGUILayout.Space ();

		#region フォーカス関連
		//var window = CreateScript.GetWindow<CreateScript> (true, "CreateScript");
		//window.Focus (scriptName);
		//名前を付けるTextFiledにフォーカスを当てる
		//GUI.SetNextControlName ("ScriptName");
		//EditorGUI.FocusTextInControl ("ScriptName");

		//GUI.FocusControl ("");
		#endregion

		//スクリプト名を入力
		scriptName = EditorGUILayout.TextField ("ScriptName", scriptName);
		//コンパイル中は操作できないように
		EditorGUI.BeginDisabledGroup (EditorApplication.isCompiling);
		EditorGUILayout.Space ();
		EditorGUILayout.LabelField ("ScriptType", EditorStyles.boldLabel);
		selected = GUILayout.Toolbar (selected, new string[] { "Default", "Custom", "Manager", "Select" }, GUILayout.Height (40));
		if (selected == 3)
		{
			if (GUILayout.Button ("テンプレート選択", GUILayout.Height (40)))
			{
				selectTemplatePath = EditorUtility.OpenFilePanel ("テンプレート選択", "Assets/Reference", "txt");
			}
			EditorGUILayout.LabelField ("選択したパス");
			style.wordWrap = true;
			EditorGUILayout.SelectableLabel (selectTemplatePath, style);
		}
		//Createボタンを押してスクリプト生成し、ウィンドウを閉じる
		if (GUILayout.Button ("Create", GUILayout.Height (40)))
		{
			PathSet ();
			switch (selected)
			{
				case 0:
					scriptText = CreateNewScript (defaultTemplatePath);
					break;
				case 1:
					scriptText = CreateNewScript (customTemplatePath);
					break;
				case 2:
					scriptText = CreateNewScript (managerTemplatePath);
					break;
				case 3:
					if (selectTemplatePath == "")
					{
						Debug.LogError ("テンプレートを選択していません");
						return;
					}
					scriptText = CreateNewScript (selectTemplatePath);
					break;
			}
			//csファイルとしてScriptsフォルダに保存
			File.WriteAllText (fullPath, scriptText, Encoding.UTF8);

			AssetDatabase.Refresh ();
			Close ();
		}
		EditorGUI.EndDisabledGroup ();
	}

	private void PathSet ()
	{
		fullPath = GetCurrentDirectory () + "/" + scriptName + ".cs";
	}

	private string CreateNewScript (string templatePath)
	{
		TemplateCheck (templatePath);
		//テンプレートを読み込んでtempに格納
		StreamReader reader = new StreamReader (templatePath, Encoding.GetEncoding ("Shift_JIS"));
		string template = reader.ReadToEnd ();
		reader.Close ();

		//テンプレート中の文字列"#SCRIPTNAME#"をスクリプト名に置換
		return template.Replace ("#SCRIPTNAME#", scriptName);
	}

	/// <summary>
	/// 危険な処理だが、とりあえずこれでやる
	/// カレントパスの取得
	/// </summary>
	/// <returns></returns>
	private string GetCurrentDirectory ()
	{
		var flag = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance;
		var asm = Assembly.Load ("UnityEditor.dll");
		var typeProjectBrowser = asm.GetType ("UnityEditor.ProjectBrowser");
		var projectBrowserWindow = EditorWindow.GetWindow (typeProjectBrowser);
		return (string)typeProjectBrowser.GetMethod ("GetActiveFolderPath", flag).Invoke (projectBrowserWindow, null);
	}

	/// <summary>
	/// テンプレートファイルを保存しておく
	/// </summary>
	private void TemplateSave()
	{
		//保存用ファイルがないなら作成

		//ファイルにパスを書き込む
	}

	private void TemplateCheck (string templatePath)
	{
		string temp = templatePath.Replace ("Assets", "");

		if (File.Exists (string.Format ("{0}{1}", Application.dataPath, temp)))
		{
			return;
		}
		else if (Directory.Exists (string.Format ("{0}{1}", Application.dataPath, "/Reference")))
		{
			Debug.LogError ("CreateScript.cs：テンプレートファイルがありません");
			Debug.LogError ("CreateScript.cs：テンプレートファイルを生成します");
			string create = string.Format ("{0}{1}", Application.dataPath, temp);
			File.Create (create);
			return;
		}
		else
		{
			Debug.LogError ("CreateScript.cs：テンプレート格納用のフォルダがありません");
			Debug.LogError ("CreateScript.cs：テンプレートファイルがありません");
			Debug.LogError ("CreateScript.cs：フォルダとファイルを生成します");
			Directory.CreateDirectory (string.Format ("{0}{1}", Application.dataPath, "/Reference"));
			string create = string.Format ("{0}{1}", Application.dataPath, temp);
			File.Create (create);
			return;
		}
	}
}
