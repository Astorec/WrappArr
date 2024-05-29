Currently a WIP and doesn't really do much currently. Can connect and then get Calendar information based on the ID. Should hopefully be able to make a request for new series eventually.

Currently focusing on Sonarr and Radarr but will add others in the future.

# Setting Up the Client Connection

This guide will walk you through the process of setting up a client connection using the `ApiInit` class in our application.

## Prerequisites

Before you begin, ensure you have the following information:

- The IP address of the server
- The port that Sonarr is running on
- The API Key (can be found under General Settings on the Sonarr Server)

## Steps

1. **Initialize the `ApiInit` class**

    First, you need to create an instance of the `ApiInit` class. Pass the IP address, port, and API Key to the constructor as shown below:

    ```csharp
    var apiInit = new ApiInit("192.168.1.195", 8989, "API KEY");
    ```

    Replace `"192.168.1.195"`, `8989`, and `"API KEY"` with your server's IP address, port, and API Key respectively.

2. **Login to the server**

    After initializing the `ApiInit` class, you can login to the server by calling the `Login` method:

    ```csharp
    await apiInit.Login();
    ```

    This will send a POST request to the `/login` endpoint of the server. The server's response will be printed to the console.

3. **Get the `RestClient` instance**

    Once you're logged in, you can get the `RestClient` instance by calling the `GetClient` method:

    ```csharp
    var client = apiInit.GetClient();
    ```
