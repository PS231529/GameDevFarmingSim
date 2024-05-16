using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractController : MonoBehaviour
{
    CharacterController2D character;

    private void Awake()
    {
        character = GetComponent<CharacterController2D>();
    }
}
