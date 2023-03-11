using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CharacterButton : MonoBehaviour
{
	[SerializeField] private CharacterData _characterData;

	public CharacterData CharacterData => _characterData;
	public Button Button { get; private set; }

    private void Awake()
    {
        Button = GetComponent<Button>();
    }

    public Button GetButton()
    {
        return GetComponent<Button>();
    }
}