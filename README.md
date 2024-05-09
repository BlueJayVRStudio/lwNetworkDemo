# Lightweight Network Demo

## Purpose: 
To implement a lightweight multiplayer networking solution to eliminate latency at all costs. This is necessary for smooth, real-time playability in extended reality within local network.

## General structure: 
Client-Server architecture written on top of peer-to-peer, UDP only communication.

## Features and Specs:
* No server or client RPC’s. Server streams each network object’s state as serialized representation, likewise for player controller positions and joystick axes. For serialization, this project uses ProtoBuf.
* Network object transforms (from server) and controller positions and axes (from client) are streamed without acknowledgements. On both the client and server side, only the most recent packet in the receive queue is accepted. The net result is the ability for clients to see the impact of their physical actions at the speed of client-server ping. With a good router that may even average around 5 to 10 ms wireless! Recent look into the Unity Netcode docs suggests serialized network transforms on the client side are stored in a buffer to smooth out irregular packet deliveries from the server, and from the looks of it, as many as 5 frames can be skipped from the reception of a packet. At 60 tick-rate that is an 83 ms delay, and at 120 tick-rate a 41 ms delay. Even within a local network, that is still tens of additional milliseconds of latency for the purpose of graphical fidelity. I have not personally investigated the source code, so I will not make any definitive statements, but it does seem to be consistent with the behaviors I have observed using Netcode. While this amount of latency seems reasonable for PC gaming (and, in fact, Netcode is highly optimized for reduced bandwidth and true remote client-server architecture), it heavily degrades immersion for shared space mixed reality experience and is completely impractical for sports-based games.
>Reference - https://docs-multiplayer.unity3d.com/netcode/current/components/networktransform/#:~:text=Graphic%20of%20a%20buffered%20tick%20between%20the%20server%20and%20a%20client%20(that%20is%2C%20interpolation)

* Input from client requires server acknowledgement to prevent unexpected input related behaviors. Performance wise, there is almost no issue as inputs are invoked immediately, just like server RPC in Netcode. There might be concerns about input latency when it comes to quick successive player inputs, but current tests do not indicate input latency issues.
* At 120 tick-rate, you can expect about outgoing 0.3 Mbps per transform (no scale) per client. Lightweight Network does not yet implement position or rotational threshold, so bandwidth can still be optimized.

## Design Diagrams:

<p align="center">
  <img src="README_RESOURCES/ConnectionPhase.png"/>
  <br>
  <img src="README_RESOURCES/Session.png"/>
</p>

## Testing considerations:
* If you are running network tests with Unity Editor on Windows, make sure to allow Unity Editor through firewall. The editor tends not to play nicely with Windows Firewall.

* As much as I want to believe that WiFi 6 would be a game changer for multiplayer modes, its performance seems unstable on Quest 3. For now, I would suggest using WiFi 5 for reliability.
