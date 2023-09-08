using NUnit.Framework;

namespace JsonPatch.Json.Net.Tests
{
    public sealed class UsageExampleTests
    {
        [Test]
        public void ExecutingJsonPatchFromJsonStrings_WithException()
        {
            var originalDocString = "{\"baz\": \"qux\",\"foo\": \"bar\"}";
            var patchString = "[{\"op\": \"replace\",\"path\": \"/baz\",\"value\": \"boo\"}]";
            var result = JPatch.Patch(originalDocString, patchString);
        }

        [Test]
        public void ExecutingJsonPatchFromJsonStrings_WithoutException()
        {
            var originalDocString = "{\"baz\": \"qux\",\"foo\": \"bar\"}";
            var patchString = "[{\"op\": \"replace\",\"path\": \"/baz\",\"value\": \"boo\"}]";
            var success = JPatch.TryPatch(originalDocString, patchString, out var resultString, out var patchFailReason);
        }
    }
}
