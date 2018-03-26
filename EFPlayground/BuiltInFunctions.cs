using EntityFramework.Functions;

namespace CustomFunctionOnJsonField
{
    public static class BuiltInFunctions
    {
        [Function(FunctionType.BuiltInFunction, "JSON_VALUE")]
        public static string JsonValue(this string field, string pattern) => Function.CallNotSupported<string>();
    }
}