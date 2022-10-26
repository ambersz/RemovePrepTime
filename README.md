# RemovePrepTime
Extends the PlateUp LiveSplit integration to exclude prep time between days from the game time timer.

# Installation

* Requires a mod loader like Bepinex.
    * Instructions for Bepinex: Download the 64-bit version of Bepinex and follow steps 1-3 [here](https://docs.bepinex.dev/articles/user_guide/installation/index.html#where-to-download-bepinex)
    * Note: The path to your game root may look something like `C:\Program Files (x86)\Steam\steamapps\common\PlateUp\PlateUp`
 * Download the `RemovePrepTime.dll` file attached to the latest release [here](https://github.com/ambersz/RemovePrepTime/releases) and move it into the Bepinex plugins directory.    
     * If the plugins directory does not exist, try running PlateUp once first to let Bepinex do the initial setup
     * Note: The path to your plugins directory may look something like `C:\Program Files (x86)\Steam\steamapps\common\PlateUp\PlateUp\BepInEx\plugins`
  * Installation done! The mod will now automatically send game time information to LiveSplit while the PlateUp LiveSplit integration is active.

# Additional LiveSplit Setup
This section assumes you have already set up LiveSplit and LiveSplit.Server by following the directions in the PlateUp wiki.

## Compare against game time
If you want to see your split +/- compared against game times, right click the LiveSplit window > Compare Against > Game Time


## Only display game time
If you want to show game time as your live timer:    
right click the LiveSplit window > Edit Layout... > Layout Settings > Timer    
Set Timing Method to Game Time

## Display both game time and real time
First follow the directions for (Only display game time). Then:    
right click the LiveSplit window > Edit Layout... > + > Timer > Detailed Timer    
Layout Settings > Detailed Timer    
Set Timing Method to Real Time
