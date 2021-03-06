# Notes
## Section 4
Argon Assault - Rails Shooter, 50 Lectures: [73](https://www.udemy.com/unitycourse2/learn/v4/t/lecture/8401196) - [118](https://www.udemy.com/unitycourse2/learn/v4/t/lecture/8859276)

## Game design
- For this type of game it's good to have [_Intensity x Time_ Beat Chart](https://community.gamedev.tv/t/be-the-first-to-post-for-level-design-beat-chart/50195). Rail Shooter should be like roller coaster. No 10 seconds should be the same.

## What's new
- Terrain rendering takes a lot of power. To optimize performance, some [settings](https://docs.unity3d.com/Manual/terrain-OtherSettings.html) can be tweaked
  - Pixel Error - higher values indicate lower accuracy of the mapping between the terrain maps and the generated terrain but lower rendering overhead
  - Base Map Distance - Maximum distance at which terrain textures will be displayed at full resolution
  - Cast Shadows
- Another way to optimize performance during development is to turn off Auto Generation of lighting in Lighting Settings
- Terrain data is stored in binary form and can be shared between game objects (e.g. if scene will be duplicated, duplicate terrain will use the same binary ASSET). This binary data can be converted to text using Unity Tool binary2text.exe
- When Input is keyboard/mouse larger Sensitivity is responsible for faster response time, and larger Gravity - for faster time the input recenters.
- Script properties can have [Tooltips](https://docs.unity3d.com/ScriptReference/TooltipAttribute.html)
- Internally rotation is stored as Quaternion, so we need to use [Quaternion.Euler](https://docs.unity3d.com/ScriptReference/Quaternion.Euler.html) to convert 3D XYZ rotation to 4D XYZW rotation.
- Order of rotation matters. Rotating by Y and then by X is not the same as rotating by X and then by Y, e.g. using `transform.Rotate`. In the latter example Z will also change, when rotating by Y after X.
- By holding down Ctrl and rotating objects using _Rotate Tool_ the values will be changed by certain amount, e.g. 0, 15, 30 degrees.
- Messages (AKA events) to other scripts on the object can be sent using [SendMessage](https://docs.unity3d.com/ScriptReference/GameObject.SendMessage.html). This way you don't need script's reference in the caller.
- Game objects can be enabled/disabled through code using [SetActive](https://docs.unity3d.com/ScriptReference/GameObject.SetActive.html)
- Active objects can be found using [FindObjectOfType](https://docs.unity3d.com/ScriptReference/Object.FindObjectOfType.html)
- Collisions with Particles can be handled using [OnParticleCollision](https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnParticleCollision.html)
- Components can be added programmatically using [AddComponent](https://docs.unity3d.com/ScriptReference/GameObject.AddComponent.html)
- [Timeline](https://docs.unity3d.com/Manual/TimelineSection.html) is used to create cinematic content, game-play sequences, audio sequences and complex particle effects
  - Animation Track is used to change model animations or change its Transform values manually
  - Control Track lets you start other Timelines in the main one
  - Activation Track is responsible for GameObject's Active state - enable/disable it, e.g. activate different Cameras during the clip
  - Audio Track is for playing Audio Clips. Volume and other properties can be adjusted by adding Audio Source object
- [Fog](https://docs.unity3d.com/Manual/PostProcessing-Fog.html) can be added in Lighting Settings

## Assets used
- Textures & Materials:
  - [_PBR Materials_ by Epyphany games](https://assetstore.unity.com/packages/2d/textures-materials/24-pbr-materials-for-unity-5-51991)
  - [_Skybox Volume 2 ..._ by Hedgehog Team](https://assetstore.unity.com/packages/2d/textures-materials/sky/skybox-volume-2-nebula-3392)
- Models:
  - [_Star Sparrow ..._ by Ebal Studios](https://assetstore.unity.com/packages/3d/vehicles/space/star-sparrow-modular-spaceship-73167)
  - [_... Sc-Fi Space Objects_ by Ebal Studios](https://assetstore.unity.com/packages/3d/environments/sci-fi/modular-sc-fi-space-objects-120608)
  - [_... Asteroids_ by Ebal Studios](https://assetstore.unity.com/packages/3d/environments/sci-fi/space-shooter-asteroids-96444)
  - [_... Arcade Style Spaceships_ by Ebal Studios](https://assetstore.unity.com/packages/3d/vehicles/space/generic-arcade-style-spaceships-97811)
- Audio:
  - [_RailJet / Long Seamless Loop_ by DST](https://opengameart.org/content/railjet-long-seamless-loop) (Original taken from [nosoapradio.us](http://www.nosoapradio.us/))
  - [_Voice Clips_ from Star Fox 64](http://www.starfox64.baldninja.com/sf64snds.htm)
- [_Standard (Utility) Assets_ by Unity Technologies](https://assetstore.unity.com/packages/essentials/asset-packs/standard-assets-32351)
- [_SD Hall_ Font by Sompong Pradubboot](https://www.dafont.com/sd-hall.font)
- [Image from _Bumblebee figure_ by Hasbro](https://shop.hasbro.com/en-us/product/transformers-mighty-muggs-bumblebee-3:0230BA5B-E019-4698-B4DE-252547F6FDE0)
