using UnityEngine;
using Unity.Services.CloudCode.GeneratedBindings;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.CloudCode;

public class CallWorld : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async void Start()
    {
        // Initialize Unity Services Core SDK
        await UnityServices.InitializeAsync();

        // Authenticate by logging into anonymous account
        await AuthenticationService.Instance.SignInAnonymouslyAsync();

        try
        {
            // Call the function
            var module = new MyModuleBindings(CloudCodeService.Instance);
            var result = await module.SayHello("World");

            Debug.Log(result);
        } catch (CloudCodeException exception)
        {
            Debug.Log(exception);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
