The previous team has decided to stop their development for Tremor. The mod has now been transferred to Jofairden.

Thanks to all the collaborators, Tremor will remain available and bugs will be fixed.


# Tremor
[Thread](https://forums.terraria.org/index.php?threads/tremor-remastered.28695/)

# Latest changelogs

## Changelogs for v1.3.2.3
Please note that the Tremor wiki (by gamepedia) will no longer be endorsed by me, or anyone involving Tremor's development. By no means should this wiki be considered official, and I will advise against using it. I do not deem this wiki a reputable source of information anymore, and neither should you: if you have a question, you can ask me and I will give you an honest answer. 


Fixes:
 - Improved/fixed mod unload (thanks jopojelly)
 - Fixed missing banner assignments (prep for future tml release) (thanks jopojelly)
 - Fixed glowmask related errors for servers (thanks Rartrin)
 - Bosss Heater of Worlds and Ancient Dragon no longer take knockback
 - Now only Ancient dragon head shows in cheat sheet UI and not the other segments
 - Fixed Tremor removing a recipe for Super Healing Potion
 - Fixed Startrooper not being able to get the name 'Parker' and 'Lambert'
 - Fixed Undertaker not being able to get the name 'Spots' and 'Hargon'
 - (hopefully:silent changes) Fixed Startrooper and Undertaker allegedly moving in without having killed the required bosses
 - Fixed the Glass Potion buff not resetting defense to 0

Other or specific notes:
 - I added hooks to tML to allow for custom crit chance. This mean alchemical crit chance will be a thing when tML updates
 - Glowmasks now support useStyle 5 (thanks Rartrin)
 - Improved the Glass Potion (and buff) tooltip

 - Robotic Dead Head and Dead Head
 -- Fixed Dead Head accessory not granting throwing crit chance, and not granting alchemical damage and crit chance
 -- Fixed Robotic Dead Head accessory nto granting throwing crit chance, and not granting alchemical damage and crit chance
 -- Improved the tooltips for both Robotic Dead Head and Dead Head

Motherboard improvements!
 The code for Motherboards has been refactored and worked on.
 Hopefully this means there are no more multiplayer issues, or at least less. Please let me know if you encounter any.
 In addition to improvements, I have repurposed a lot of DD2 event sound effects in the boss fight to really improve on it. (thanks Skiphs for helping!)
 You will see for yourself, the additions and changes to both visual and auditive effects during the fight.

 - Fight changes
 -- Signal drones' AI is improved. They will target a nearby player and home in on them in a grid like fashion. This works together with their attack. Because of this change, the drones themselves have a hefty cooldown for hitting players with a body attack.
 -- The laser beams Motherboard shoots in her first phase now more accurately target the player, instead of random places

 - Known issues
 -- When Motherboard her two super laser beams in phase 2 have a long distance from the ground, it is known that this causes a hit on FPS. Try to fight her closer to the ground to avoid this issue, I hope I will be able to find the cause of this.

# Report bugs
Please make an [issue](https://github.com/Jofairden/Tremor/issues) to report the bug you found. Please check first if the mod has already been reported.
When you report a bug, please provide at the very least the following information:
* tModLoader version you are using
* Tremor version you are using
* What happens?
* What should be happening?
* A FULL log of the error(s)
  * You can get a full log by clicking on 'Open Logs' when you get the error. This log provides more information. 

If applicable, provide the scenario(s) in which the bug occurs.

# Making pull requests
Help is always appreciated. Please prepend the appropiate tag in your PR so I can easily triage it:
* [Rework]
* [Bug squash]
* [Refactor]

Rework means you reworked some code entirely. Bug squash means you have fixed bugs. Refactor or revise means you've gone over some code and refactored it. Code comments are highly appreciated.
**If multiple tags could be appropiate, it's fine if you omit them and explain in the PR itself.**

_As for now, I will ignore all rebalance requests or PRs. Rebalancing is not a priority right now._
