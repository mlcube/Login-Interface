using System;
using UnityEngine;
using UnityEngine.UIElements;

public class logiin : MonoBehaviour
{
    private string _userLogin = ""; // Variables to store user login 
    private string _userPassword = ""; // Variables to store user password

    [NonSerialized] UIDocument _UIDocument; // Reference to the UIDocument component
    VisualElement _RootElement; // Root element of the UI
    Button _LoginButton; // Reference to the login button
    TextField _UsernameField; // Reference to the username input field
    TextField _PasswordField; // Reference to the password input field

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _UIDocument = GetComponent<UIDocument>(); // Get the UIDocument component attached to this GameObject
        _RootElement = _UIDocument.rootVisualElement; // Get the root element of the UI Document
    }

    void OnEnable()
    {
        // Find the username and password fields by their names in the UI Document
        _UsernameField = _RootElement.Q<TextField>("fieldLogin"); // Find the TextField with name "usernameField"
        _PasswordField = _RootElement.Q<TextField>("fieldPassword"); // Find the TextField with name "passwordField"
        if (_UsernameField == null || _PasswordField == null) // Check if the fields are not found
        {
            Debug.LogError("Username or Password field not found!"); // Log an error if any field is missing
            return; // Exit the method if fields are not found
        }
        // Initialize the fields or set default values if needed
        _UsernameField.value = string.Empty; // Clear the username field
        _PasswordField.value = string.Empty; // Clear the password field
        // Add a click event listener to the login button
        _LoginButton = _RootElement.Q<Button>("btnLogin"); // Find the button with name "btnlogin"
        if (_LoginButton == null) // Check if the login button is not found
        {
            Debug.LogError("Login button not found!"); // Log an error if the button is missing
            return; // Exit the method if the button is not found
        }
        _LoginButton.clicked += OnLoginButtonClicked; // Add a click event handler to the login button
        // Or Other method to do so
        // Validation.CheckQuery(_LoginButton, "Login button not found!"); // Custom validation method to check if the button is found
        // _LoginButton?.RegisterCallback<ClickEvent>(OnLoginButtonClicked); // Alternative way to register the click event
    }

    void OnLoginButtonClicked()
    {
        // Handle the login button click event
        _userLogin = _UsernameField.value; // Get the value from the username field
        _userPassword = _PasswordField.value; // Get the value from the password field
        // Check if the username and password are valid (this is just a placeholder, replace with actual validation logic)
        if (string.IsNullOrEmpty(_userLogin) || string.IsNullOrEmpty(_userPassword))
        {
            Debug.LogError("Username or Password cannot be empty!"); // Log an error if either field is empty
            return; // Exit the method if validation fails
        }
        // Perform login logic here, e.g., validate credentials, authenticate user, etc.
        Debug.Log($"Username: {_userLogin}, Password: {_userPassword}"); // Log the username and password for debugging purposes

        // Login logic goes here
        // Check credentials against a database, API, or any other authentication service
        Debug.Log("Login successful!"); // Log a success message if login is successful

        // Trigger a transition to another scene or UI state here
        // SceneManager.LoadScene("MainMenu"); // Example of loading a new scene after successful login
        // Close the login UI
        _RootElement.style.display = DisplayStyle.None; // Hide the login UI after successful login

        // Clear the fields after login attempt
        //_UsernameField.value = string.Empty; // Clear the username field
        //_PasswordField.value = string.Empty; // Clear the password field
    }


}
