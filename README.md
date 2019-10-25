# PeachFox
Lua Tile Map Editor

Orginally made to work with my love2D project

When running, first select your Love2D project. Then press Open Project.

It will then bring you to the Project Window. 

## TileMap Editor Tab
You will need a file to start such as: 
(["Map"] can be nil to start with)
```Lua
map = {
  ["Graphics"] = {
    ["Width"] = 16,
    ["Height"] = 16,
    ["Scale"] = 3,
  },
  ["Map"] = {
    [0] = {
      [0] = {
        ["Bg"] = {
        --It will search and replace the project dir, so make sure your assets are in the right place when creating the map
          ["File"] = "assets/TileSets/terrain.png", 
          ["Quad"] = {
            ["X"] = 48, -- Pixels
            ["Y"] = 16,
            ["W"] = 16, --Width (Pixels)
            ["H"] = 16, --Height
          },
        },
        ["Fg"] = {
          ["File"] = "assets/TileSets/outside.png",
          ["Quad"] = {
            ["X"] = 16,
            ["Y"] = 16,
            ["W"] = 16,
            ["H"] = 16,
          },
        },
        ["Physics"] = {
          ["Colliable"] = false,
        }
      }
    }
  }
}
```

Once open you can change the overall settings for the map, you can also switch to the next tab "Editor" to make a tile map

Press the big button on the right to select a tile from a tile map
  - You can drag around the view and zoom in to get a better look
Press export when you've made your Quad selection

You can set if a tile if colliable using the checkbox, and you can switch between background and foreground using the other checkbox
Click on a tile to set those settings to it. 
Foreground will draw 10 pixels smaller than it should do in a program

You can move around the camera using the movement buttons and optionally show the colliable tiles in the map with the checkbox
  - Only redraws once mouse has been released

Once finished remember to switch back to the settings tab and press "Save As" otherwise your changes will not be saved to a file
