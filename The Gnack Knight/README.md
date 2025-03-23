Controls:
WASD to move
Shift to run
Arrow keys to shooting

To add new sprites to the content:
- Open Windows PowerShell and cd into the Content folder:
	- eg. cd source\repos\the-gnack-knight\"The Gnack Knight"\Content
- Execute dotnet mgcb-editor Content.mgcb
	- If this doesn't work, enter the following command: dotnet new install MonoGame.Templates.CSharp
- Right-click Content
- Select "add""
- Select "Existing item..."
- Then select the item you wish to add.