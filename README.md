# WIP: RPCCompanion
 
 Expect bugs.
 
 This is a plugin for [StreamCompanion](https://github.com/Piotrekol/StreamCompanion) which provides detailed Rich Presence information to Discord.
 Currently two styles are supported: "Detailed" and "Minimal"
 
 ![image](https://user-images.githubusercontent.com/128091734/227660983-a094020d-97e8-4e2c-a245-c03826c9ae68.png) ![image](https://user-images.githubusercontent.com/128091734/227661021-aace49c6-02eb-47d0-907c-9d86a0e03425.png) ![image](https://user-images.githubusercontent.com/128091734/227661051-46e45067-416e-4d8b-860e-4ba0f4310fe5.png)

## Features

 - Buttons that link to your profile and your current beatmap
 - Small icon changes based on which gamemode you're currently playing
 - "Live" Mods, accuracy, 100/50/0, and Combo display (Mostly live... Discord has a rate limit of one update per 15 seconds)
 - Status changes based on what you're doing. Currently supports "Editing", "Multiplayer", "Song Select", and more!

## Upcoming features

 - Automatically detect username and profile link
 - Display time progress in beatmap (Current time / Total length)
 - Display session time (how long you've been logged in)

## Want to try it out? 
 
 1. Head over to the [Releases](https://github.com/NateOnLinux/rpcCompanion/releases) page and download the latest version.
 2. Unpack the archive (.zip)
 3. Copy everything to `C:\Program Files (x86)\StreamCompanion\Plugins` (Copy the whole Dlls folder - do not remove the file inside)
 4. Start StreamCompanion
 5. Open StreamCompanion Settings and then Discord Rich Presence
 ![image](https://user-images.githubusercontent.com/128091734/228424868-d4390393-0b94-4da3-8016-899a2eb033f5.png)
 6. Select whether you'd like Detailed or Minimal mode. 
 7. Select your server (Leave this on "Bancho" if you don't know what this is)
 8. Disable "Discord Rich Presence" in osu! settings if it's enabled
 9. Check "Enable RPC Companion"
 
 Bugs? Ideas? Submit them [here](https://github.com/NateOnLinux/rpcCompanion/issues).
 
 Feedback/Questions? Contact me on Discord @ NateOnLinux#5080 or in-game @ "Hank Hill".
 
 ### Linux Support:
 Currently Linux and MacOS are not supported (StreamCompanion does not support Linux/MacOS). A lot of the code in this project is linux-friendly, so I plan to make a CLI app with similar functionality in the future.
 
 ### License:
 This software is licensed under MIT. You can find the full text of the license [here](https://github.com/NateOnLinux/RPCCompanion/blob/master/LICENSE.txt)
