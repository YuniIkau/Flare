using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/**EditにPrefabのApplyをする項目の追加、ショートカットAlt+Aでも可能**/

public class PrefabApply
{
	//MenuのEditに追加
	[MenuItem ("Edit/PrefabApply &a")]
	static void Apply ()
	{
		//実際にここでApplyする
#if UNITY_2017 || UNITY_2018_1 || UNITY_2018_2
        EditorApplication.ExecuteMenuItem("GameObject/Apply Changes To Prefab");
#endif
#if UNITY_2018_3 || UNITY_2018_4 || UNITY_2019
		PrefabUtility.ApplyPrefabInstance (Selection.activeGameObject, InteractionMode.UserAction);
#endif
	}
}
