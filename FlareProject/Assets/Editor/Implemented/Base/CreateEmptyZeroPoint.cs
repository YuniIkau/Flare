using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/**CreateEmptyでTransformのPositionを全て0で生成する**/

public class CreateEmptyZeroPoint
{
	//表示の追加
	//第一引数はパス,%#nはショートカットキーで、Ctrl+Shift+n
	//第二引数はMenuを表示した時に実行可能かどうかのチェックを行うためのもの(isValidateFunction)
	//第三引数はpriority
	//このバージョンまではショートカットの上書きが可能だったためこうしている
#if UNITY_2017 || UNITY_2018_1 || UNITY_2018_2
    [MenuItem("GameObject/Create EmptyZero %#n", false, -1)]
#endif
#if UNITY_2018_3 || UNITY2018_4 || UNITY_2019
	[MenuItem ("GameObject/Create EmptyZero %#z", false, -1)]
#endif
	static void CreateEmptyObject ()
	{
		var obj = new GameObject ("GameObject");
		obj.transform.localPosition = Vector3.zero;
	}
}
