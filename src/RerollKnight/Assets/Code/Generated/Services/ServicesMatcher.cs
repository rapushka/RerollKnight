//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ContextMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class ServicesMatcher {

    public static Entitas.IAllOfMatcher<ServicesEntity> AllOf(params int[] indices) {
        return Entitas.Matcher<ServicesEntity>.AllOf(indices);
    }

    public static Entitas.IAllOfMatcher<ServicesEntity> AllOf(params Entitas.IMatcher<ServicesEntity>[] matchers) {
          return Entitas.Matcher<ServicesEntity>.AllOf(matchers);
    }

    public static Entitas.IAnyOfMatcher<ServicesEntity> AnyOf(params int[] indices) {
          return Entitas.Matcher<ServicesEntity>.AnyOf(indices);
    }

    public static Entitas.IAnyOfMatcher<ServicesEntity> AnyOf(params Entitas.IMatcher<ServicesEntity>[] matchers) {
          return Entitas.Matcher<ServicesEntity>.AnyOf(matchers);
    }
}
