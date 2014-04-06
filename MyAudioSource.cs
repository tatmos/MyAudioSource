using UnityEngine;
using System.Collections;
#if UNITY_WEBPLAYER
public class MyAudioSource : MonoBehaviour
{	
	private AudioSource _Mysource;

	public AudioSource source 
	{
		get
		{
			return _Mysource;
		}
	}	
	public AudioClip clip{
		set
		{
			_Mysource.clip = value;
		}
	}
	public bool isPlaying
	{
		get
		{
			return _Mysource.isPlaying;
		}
	}
	public float timeSamples
	{
		get
		{
			return _Mysource.timeSamples;
		}
	}
	public void Play()
	{
		_Mysource.Play();
	}
	public void Awake()
	{
		if(_Mysource == null){
			_Mysource = gameObject.AddComponent<AudioSource>();			
			source.rolloffMode = AudioRolloffMode.Linear;	//3Dポジション時に音が小さくなるのを軽減
		}
	}	
}
#else
public class MyAudioSource : MonoBehaviour
{	
	public class MyAudioSource : CriAtomSource
	{	
		public CriAtomSource source { 
			get
			{
				return this;
			}
		}
		public AudioClip clip{
			set
			{
				this.cueName = value.name;
			}
		}
		public bool isPlaying
		{
			get
			{
				if(this.status == Status.Playing)return true;
				return false;
			}
		}
		public float timeSamples
		{
			get
			{
				return this.time / 1000.0f * 44100f;
			}
		}
	}
}
#endif		
