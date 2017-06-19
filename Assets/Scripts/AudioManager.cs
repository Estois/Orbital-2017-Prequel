using UnityEngine;

[System.Serializable]
public class Sound
{
	
	public string name;
	public AudioClip clip;

	private AudioSource source;

	[Range (0f, 1f)]
	public float volume;
	[Range (0f, 3f)]
	public float pitch;

	public bool loop = false;

	public void SetSource (AudioSource _source)
	{
		source = _source;
		source.clip = clip;
		source.loop = loop;
		source.volume = volume;
		source.pitch = pitch;
	}

	public void Play ()
	{
		source.Play ();
	}

	public void Stop ()
	{
		source.Stop ();
	}
}

public class AudioManager : MonoBehaviour
{

	public static AudioManager instance;


	[SerializeField]
	Sound[] sound;

	void Awake ()
	{
		if (instance != null) {
			if (instance != this) {
				Destroy (this.gameObject);
			}
		} else {
			instance = this;
		}
	}

	void Start ()
	{
		for (int i = 0; i < sound.Length; i++) {
			GameObject _go = new GameObject ("Sound_ " + i + "_" + sound [i].name);
			_go.transform.SetParent (this.transform);
			sound [i].SetSource (_go.AddComponent<AudioSource> ());
		}
		PlaySound ("BGMusic");
	}

	public void PlaySound (string _name)
	{
		for (int i = 0; i < sound.Length; i++) {
			if (sound [i].name == _name) {
				sound [i].Play ();
				return;
			}
		}

		Debug.LogWarning ("AudioManager: Sound not found in array: " + _name);
	}

	public void StopSound (string _name)
	{
		for (int i = 0; i < sound.Length; i++) {
			if (sound [i].name == _name) {
				sound [i].Stop ();
				return;
			}
		}
	}
}
