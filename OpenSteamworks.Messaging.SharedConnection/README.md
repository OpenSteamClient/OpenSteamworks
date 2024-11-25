# OpenSteamworks.Messaging.SharedConnection
Allows you to send and receive messages through OpenSteamworks IClientSharedConnection.

The SharedConnection, as the name implies shares the currently logged in CM to send messages.

In order to receive messages you must register EMsg and service method handlers, depending on your use case. These are automatically set when using Send(), however other messages need to be manually registered. 