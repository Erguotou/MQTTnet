﻿using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;
using MQTTnet.Client.Subscribing;
using MQTTnet.Client.Unsubscribing;
using System;
using System.Threading;
using System.Threading.Tasks;
using MQTTnet.Client.ExtendedAuthentication;

namespace MQTTnet.Client
{
    public interface IMqttClient : IApplicationMessageReceiver, IApplicationMessagePublisher, IDisposable
    {
        bool IsConnected { get; }

        /// <summary>
        /// Gets the options which are used when connecting with the server.
        /// </summary>
        IMqttClientOptions Options { get; }

        /// <summary>
        /// Gets or sets the connected handler that is fired after the client has connected to the server successfully.
        /// Hint: Initialize handlers before you connect the client to avoid issues.
        /// </summary>
        IMqttClientConnectedHandler ConnectedHandler { get; set; }

        /// <summary>
        /// Gets or sets the disconnected handler that is fired after the client has disconnected from the server.
        /// Hint: Initialize handlers before you connect the client to avoid issues.
        /// </summary>
        IMqttClientDisconnectedHandler DisconnectedHandler { get; set; }

        Task<MqttClientConnectResult> ConnectAsync(IMqttClientOptions options, CancellationToken cancellationToken);

        Task DisconnectAsync(MqttClientDisconnectOptions options, CancellationToken cancellationToken);

        Task PingAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Sends extended authentication data.
        /// Hint: MQTT 5 feature only.
        /// </summary>
        /// <param name="data">The parameters for the extended authentication.</param>
        /// <param name="cancellationToken">A cancellation token to stop the task.</param>
        /// <returns>A <see cref="Task"/> representing any asynchronous operation.</returns>
        Task<MqttExtendedAuthenticationRequest> ReAuthenticate(MqttExtendedAuthenticationData data, CancellationToken cancellationToken);

        Task<MqttClientSubscribeResult> SubscribeAsync(MqttClientSubscribeOptions options, CancellationToken cancellationToken);

        Task<MqttClientUnsubscribeResult> UnsubscribeAsync(MqttClientUnsubscribeOptions options, CancellationToken cancellationToken);
    }
}