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
		private Audio[] m_AudioSource = null;

		private List<AudioClip> m_CacheAudio = new List<AudioClip> ();

		public enum AudioIndex : byte
		{
			NONE = 99,
			SE_1 = 0,
			SE_2 = 1,
			SE_3 = 2,
			BGM = 3,
		}
		private void Awake ()
		{
			instance = this; selfObj = null;
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
			if (m_AudioSource[(int)audioIndex].isLoadEnd == false)
			{
				Debug.LogError ("ロード完了していません");
				return;
			}
			if (m_AudioSource[(int)audioIndex].audioSource == null)
			{
				Debug.LogError ("オーディオクリップのセットがされていません");
				return;
			}
			m_AudioSource[(int)audioIndex].audioSource.Play ();
		}
		/// <summary>
		/// ループSEの作成（いる？って聞かれたら自身がない）
		/// </summary>
		/// <param name="index"></param>
		public void PlayLoopSE (AudioIndex audioIndex = 0)
		{
			m_AudioSource[(int)audioIndex].audioSource.Play ();
		}
		/// <summary>
		/// BGMの再生
		/// </summary>
		public void PlayBGM ()
		{
			m_AudioSource[(int)AudioIndex.BGM].audioSource.Play ();
		}
		#endregion Play
		public void PlayCheck ()
		{

		}

		public void AddCacheAudio (AudioClip audioClip)
		{
			if (!m_CacheAudio.Contains (audioClip))
			{
				m_CacheAudio.Add (audioClip);
			}
		}
		public AudioClip GetCacheAudio (string name)
		{
			for (int i = 0; i < m_CacheAudio.Count; ++i)
			{
				if (m_CacheAudio[i].name == name)
				{
					return m_CacheAudio[i];
				}
			}
			Debug.LogWarning ("キャッシュにオーディオがありません");
			return null;
		}
		public void CacheClear ()
		{
			m_CacheAudio.Clear ();
		}
		public void SetAudio (AudioIndex audioIndex, AudioClip audioClip)
		{
			m_AudioSource[(int)audioIndex].audioSource.clip = audioClip;
			m_AudioSource[(int)audioIndex].isLoadEnd = true;
		}
		public void SetAudio (AudioIndex audioIndex, string name)
		{
			AudioClip audioClip = GetCacheAudio (name);
			m_AudioSource[(int)audioIndex].audioSource.clip = audioClip;
			m_AudioSource[(int)audioIndex].isLoadEnd = true;
			
		}

		public void Clear (AudioIndex audioIndex)
		{
			m_AudioSource[(int)audioIndex].audioSource.clip = null;
			m_AudioSource[(int)audioIndex].isLoadEnd = false;
		}
	}
}
