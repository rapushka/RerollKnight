//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.Roslyn.CodeGeneration.Plugins.CleanupSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System.Collections.Generic;
using Entitas;

public sealed class DestroyDragRequestSystem : ICleanupSystem {

    readonly IGroup<RequestEntity> _group;
    readonly List<RequestEntity> _buffer = new List<RequestEntity>();

    public DestroyDragRequestSystem(Contexts contexts) {
        _group = contexts.request.GetGroup(RequestMatcher.Drag);
    }

    public void Cleanup() {
        foreach (var e in _group.GetEntities(_buffer)) {
            e.Destroy();
        }
    }
}
