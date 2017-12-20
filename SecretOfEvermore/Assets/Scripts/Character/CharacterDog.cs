using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDog : Character {

    public float MaxDistanceBetween = 0;


    public CharacterDog(CharacterManager characterManager, GameObject characterObject, float speed , float maxDistanceBetween) : base(characterManager, characterObject, speed)
    {
        MaxDistanceBetween = maxDistanceBetween;
    }
    // Use this for initialization
    public override void Start() {
		
	}

    // Update is called once per frame
    public override void Update () {

        if(_characterManager.SelectedCharacter == this)
        {
            // controll this character
            float movementX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            float movementY = Input.GetAxis("Vertical") * Time.deltaTime * speed;
            Debug.Log(movementX);
            _characterManager.SelectedCharacter.CharacterObject.transform.Translate(movementX, 0, movementY);
        }
        else
        {
            // else folow other character
            Vector3 otherPosition = _characterManager.SelectedCharacter.CharacterObject.transform.position;
            Vector3 myPosition = CharacterObject.transform.position;

            // get distance to player
            Vector3 Direction = (otherPosition - myPosition);
            float distance = Direction.magnitude;

            if (distance > MaxDistanceBetween)
            {
                Vector3 translation = Direction.normalized * (distance - MaxDistanceBetween);
                translation.y = myPosition.y;
                CharacterObject.transform.Translate(Direction.normalized * (distance - MaxDistanceBetween));
            }
        }

    }
}
