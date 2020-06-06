using UnityEngine;

public class AspectUtility : MonoBehaviour
{
	private void Awake()
	{
		Camera camera = GetComponent<Camera>();
		Rect rect = camera.rect;
		print((Screen.width / Screen.height));

		float scaleHeight = ((float)Screen.width / Screen.height) / ((float)9 / 16); // 縦 / 横  のascpect
		float scaleWidth = 1.0f / scaleHeight;

		if(scaleHeight < 1)
		{
			rect.height = scaleHeight;
			rect.y = (1.0f - scaleHeight) / 2.0f;
		}
		else
		{
			rect.width = scaleWidth;
			rect.x = (1.0f - scaleWidth) / 2.0f;
		}
		camera.rect = rect;
	}

}
