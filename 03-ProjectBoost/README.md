# Notes
## What's new
- Use Rigidbody's [AddRelativeForce](https://docs.unity3d.com/ScriptReference/Rigidbody.AddRelativeForce.html) to add a force relative to its coordinate system.
- Pivot point is the object's origin around which it rotates. It's very crucial for compound objects, or to change rotation point of a simple object.
- To control rotation manually use [Rigidbody.freezeRotation](https://docs.unity3d.com/ScriptReference/Rigidbody-freezeRotation.html)
- Unity file structure:
  - GameObjects and their Components are at the root, they are linked through fileIDs:

        --- !u!1 &1992515815
        GameObject:
          ...
          m_Component:
          - component: {fileID: 1992515819}
          ...
          m_Name: Cube
          ...
        --- !u!4 &1992515819
        Transform:
          ...
          m_GameObject: {fileID: 1992515815}
          m_LocalRotation: {x: 0, y: 0, z: 0, w: 1}
          m_LocalPosition: {x: -7, y: 0, z: 8}
          m_LocalScale: {x: 1, y: 1, z: 1}
          m_Children: []
          m_Father: {fileID: 0}
          ...
        ...
  - If object is prefabbed, only its modifications are saved in the scene:

        --- !u!1001 &1071542712
        Prefab:
          ...
          m_Modification:
            ...
            m_Modifications:
            - target: {fileID: 4906788035694416, guid: ac36817f9f1245a4da10b36e952b0b8c, type: 2}
              propertyPath: m_LocalPosition.x
              value: -7.5790873
              objectReference: {fileID: 0}
            ...
            - target: {fileID: 4906788035694416, guid: ac36817f9f1245a4da10b36e952b0b8c, type: 2}
              propertyPath: m_RootOrder
              value: 7
              objectReference: {fileID: 0}
            m_RemovedComponents: []
          m_SourcePrefab: {fileID: 100100000, guid: ac36817f9f1245a4da10b36e952b0b8c, type: 2}
          m_IsPrefabAsset: 0
        ...
  - Everything else is in the Prefab file:

        --- !u!1001 &100100000
        Prefab:
          ...
          m_Modification:
            ...
            m_Modifications: []
            m_RemovedComponents: []
          m_SourcePrefab: {fileID: 0}
          ...
          m_IsPrefabAsset: 1
        --- !u!1 &1003093614604834
        GameObject:
          ...
          m_Component:
          - component: {fileID: 4906788035694416}
          ...
        --- !u!4 &4906788035694416
        Transform:
          m_GameObject: {fileID: 1003093614604834}
          ...
        ...
- It's possible to Copy Component and Paste it or only its Values to another GameObject
- If on Scene load some light is missing, then open Lighting Settings Window and try Generating Lighting manually for each Scene
- [ParticleSystem.Play](https://docs.unity3d.com/ScriptReference/ParticleSystem.Play.html)
- Prefabs cannot be nested under other prefabs, i.e. if it is nested and you'll change original prefab, prefab nested under another prefab won't change as it is just a copy of that original prefab.
- [Debug.isDebugBuild](https://docs.unity3d.com/ScriptReference/Debug-isDebugBuild.html)

## Assets used
- Sound FX:
  - [_Rocket Launch_ by primeval_polypod](https://freesound.org/people/primeval_polypod/sounds/158894/)
  - [_Missile explosion_ by smcameron](https://freesound.org/people/smcameron/sounds/51467/)
