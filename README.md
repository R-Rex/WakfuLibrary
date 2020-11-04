# WakfuLibrary
Not updated, this project is for profit to learn reverse engineering knowledge, this project has no affiliation with ANKAMA GAME
Library for creating a wakfu bot

# Documentation

### Start new Bot
``` C#
SocketBot bot = new SocketBot();
Thread newThreadBot = new Thread(new ThreadStart(bot.StartingBot));
newThreadBot.Start();
```
### How do I add a new package?

Example : https://github.com/R-Rex/WakfuLibrary/blob/master/Protocol/Auth/Packet17.cs

# Functionality

This connect to the selection server

# TODO
* Packet reader
* Access to the world
* Simpler login
