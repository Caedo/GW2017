using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInput {
    public string horizontal;
    public string vertical;
    public string jump;
    public string itemThrow;
    public string itemUse;
}

public class Player : MonoBehaviour {

	public new AudioClip[] audio;

	public Player m_OtherPlayer;
    public PlayerType m_PlayerType;
    public string m_PlayerName;
    public PlayerInput m_PlayerInput;

	public float PlayTimeMin = 40.0f;
	public float PlayTimeMax = 60.0f;
	private float timeToPlay = 20.0f;
	private int numberClip;

	AudioSource source;

	void Awake(){
		source = GetComponent<AudioSource> ();
	}

    void SetupPlayerInput() {
         m_PlayerInput = new PlayerInput()
           {
                horizontal = m_PlayerType.ToString() + "horizontal",
                vertical = m_PlayerType.ToString() + "vertical",
                jump = m_PlayerType.ToString() + "jump",
                itemThrow = m_PlayerType.ToString() + "throw",
                itemUse = m_PlayerType.ToString() + "use"
            };

    }

    public void Initialize(PlayerInfo info) {
        m_PlayerName = info.m_Name;
        m_PlayerType = info.m_PlayerType;

        SetupPlayerInput();
    }
	void OnCollisionEnter(Collision collision){

		if (collision.relativeVelocity.magnitude >10 ) {
			source.clip = audio [0];
			source.Play ();
		}
	}
	void Update (){
		timeToPlay -= Time.deltaTime;

		if(timeToPlay <= 0)
		{
            numberClip = Random.Range(1, audio.Length);
			timeToPlay = Random.Range(PlayTimeMin, PlayTimeMax);
			source.clip = audio [numberClip];
			source.Play ();
		}
	}
}
