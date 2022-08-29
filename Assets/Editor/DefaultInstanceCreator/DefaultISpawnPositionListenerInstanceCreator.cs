using System;
using Entitas.VisualDebugging.Unity.Editor;

public class DefaultISpawnPositionListenerInstanceCreator : IDefaultInstanceCreator {

    public bool HandlesType(Type type) {
        return type == typeof(ISpawnPositionListener);
    }

    public object CreateDefault(Type type) {
        // TODO return an instance of type ISpawnPositionListener
        throw new NotImplementedException();
    }
}
