namespace InstagramApp
{
    // A class to easily access constant values
    class Constants
    {
        // Name of your app
        public static string AppName = "ExampleName";

        // Your client id. You get it from your registered client on Instagram. (https://www.instagram.com/developer/clients/manage/)
        public static string ClientId =  "eefbf801250e4611880cbf07417ef780";

        // Specify what you want to access from the Instagram API. I didn't use all of them in this example.
        // For more scope parameters look at the Instagram API documentation. (https://www.instagram.com/developer/authorization/)
        public static string Scopes = "basic public_content likes";

        // The authorization URL of Instagram. Note that I use client-side authentication in this example.
        // Change the response_type to "code" to use server-side authentication. (https://www.instagram.com/developer/authentication/)
        // Don't forget to insert your client_id and redirect_uri in the url.
        public static string AuthorizationUrl = "https://api.instagram.com/oauth/authorize/?client_id=eefbf801250e4611880cbf07417ef780&redirect_uri=https://localhost:3000/callback&response_type=token";

        // Your redirect URI. The URI must match with the registered redirect URI of your Instagram client. (https://www.instagram.com/developer/clients/manage/)
        public static string RedirectUri = "https://localhost:3000/callback";
    }
}
