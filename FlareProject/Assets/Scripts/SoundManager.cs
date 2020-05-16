using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者：佐伯
//内容：サウンドの管理クラス
//基本的にここでサウンド関連すべてやる
//もしくはSoundUtliみたいのを作ってそこで外部からの操作を逃がす
//Managerオブジェクトにアタッチし、SoundPlayerオブジェクトを参照している

namespace Manager
{
	public class SoundManager : ManagerBase<SoundManager>
	{
		[Serializable]
		private class Audio
		{
			public AudioSource audioSource;
			[HideInInspector]
			public bool isLoadEnd;
		}
		//UnityEditor側で設定されている想定（後々変えるかも）
		[SerializeField]
		private Audio[] m_AudioSourcea = null;

		private List<Audio> m_CacheAudio = new List<Audio> ();

		public enum AudioIndex:byte
		{
			NONE = 99,
			SE_1 = 0,
			SE_2 = 1,
			SE_3 = 2,
			BGM = 3,
		}
		private void Awake ()
		{
			instance = this;
		}
		private void Start ()
		{
			//セットアップ系（使用するようになってからメソッドに分けていく）
			//m_AudioSourcea[(int)AudioIndex.SE_1].loop = false;
			//m_AudioSourcea[(int)AudioIndex.SE_2].loop = false;
			//m_AudioSourcea[(int)AudioIndex.SE_3].loop = false;
			//m_AudioSourcea[(int)AudioIndex.BGM].loop = true;
		}

		#region Play
		/// <summary>
		/// SEの再生
		/// </summary>
		/// <param name="index">再生するプレイヤーの選択</param>
		public void PlaySE (AudioIndex audioIndex = 0)
		{
			if (m_AudioSourcea[(int)audioIndex].isLoadEnd == true)
			{
				m_AudioSourcea[(int)audioIndex].audioSource.Play ();
			}
		}
		/// <summary>
		/// ループSEの作成（いる？って聞かれたら自身がない）
		/// </summary>
		/// <param name="index"></param>
		public void PlayLoopSE(AudioIndex audioIndex = 0)
		{
			m_AudioSourcea[(int)audioIndex].audioSource.Play ();
		}
		/// <summary>
		/// BGMの再生
		/// </summary>
		public void PlayBGM ()
		{
			m_AudioSourcea[(int)AudioIndex.BGM].audioSource.Play ();
		}
		#endregion Play

		public void SetAudio(AudioIndex audioIndex, AudioClip audioClip)
		{
			m_AudioSourcea[(int)audioIndex].audioSource.clip = audioClip;
			m_AudioSourcea[(int)audioIndex].isLoadEnd = true;
		}

		#region Load
		public void Load (string name)
		{

		}
		public void Load ()
		{

		}
		#endregion Load

		public void Clear(AudioIndex audioIndex)
		{
			m_AudioSourcea[(int)audioIndex].audioSource.clip = null;
			m_AudioSourcea[(int)audioIndex].isLoadEnd = false;
		}


		private void Update ()
		{
			if (Input.GetKeyDown (KeyCode.X))
			{
				Clear (AudioIndex.SE_1);
				StartCoroutine (Play ());
				
			}
		}
		private IEnumerator Play()
		{
			ResourceManager.instance.SoundLoadAsync ("SE1", AudioIndex.SE_1);
			while (m_AudioSourcea[(int)AudioIndex.SE_1].isLoadEnd == false)
			{
				yield return null;
			}
			PlaySE (AudioIndex.SE_1);
			yield break;
		}
	}
}
