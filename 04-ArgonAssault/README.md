# Notes
## What's new
- Terrain rendering takes a lot of power. To optimize performance, some [settings](https://docs.unity3d.com/Manual/terrain-OtherSettings.html) can be tweaked
  - Pixel Error - higher values indicate lower accuracy of the mapping between the terrain maps and the generated terrain but lower rendering overhead
  - Base Map Distance - Maximum distance at which terrain textures will be displayed at full resolution
  - Cast Shadows
- Terrain data is stored in binary form and can be shared between game objects (e.g. if scene will be duplicated, duplicate terrain will use the same binary ASSET). This binary data can be converted to text using Unity Tool binary2text.exe
- When Input is keyboard/mouse larger Sensitivity is responsible for faster response time, and larger Gravity - for faster time the input recenters.
- Internally rotation is stored as Quaternion, so we need to use [Quaternion.Euler](https://docs.unity3d.com/ScriptReference/Quaternion.Euler.html) to convert 3D XYZ rotation to 4D XYZW rotation.

## Assets used
- Textures & Materials:
  - [_PBR Materials_ by Epyphany games](https://assetstore.unity.com/packages/2d/textures-materials/24-pbr-materials-for-unity-5-51991)
  - [_Skybox Volume 2 ..._ by Hedgehog Team](https://assetstore.unity.com/packages/2d/textures-materials/sky/skybox-volume-2-nebula-3392)
- [_Star Sparrow ..._ by Ebal Studios](https://assetstore.unity.com/packages/3d/vehicles/space/star-sparrow-modular-spaceship-73167)
- [_Star Commander1_ by DL Sounds](https://www.dl-sounds.com/royalty-free/star-commander1/)
- [_Standard (Utility) Assets_ by Unity Technologies](https://assetstore.unity.com/packages/essentials/asset-packs/standard-assets-32351)
