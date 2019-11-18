# Forces-of-nature
HackNotts 2019 Submission
A game built in 24 hours @ HackNotts 2019 - Finalist and winner of best use of Python prize
[DevPost](https://devpost.com/software/a-guy-with-his-phone-rise-of-elements)

A multiplayer survival platformer game based on the 4 elements implementing the Twilio API to receive instructions from players via WhatsApp which affect the environment of the game. The instructions provided lead to 4 different kinds of natural disasters which deal damage to the games main player.

### How it's built
**Twilio Integration**
We integrated Twilio using their Python API using 2 scripts to send and receive messages to the user. Using the web framework flask to listen for messages and we then used the python script to process the incoming data. The outgoing messages use Twilios CLI to send messages to the user.

**Unity**
We build the remainder of our game using the Unity Game Engine 
