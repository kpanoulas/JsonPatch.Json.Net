using Newtonsoft.Json.Linq;
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

        [Test]
        public void ExecutingJsonPatchFromJTokesStrings_WithException()
        {
            var originalDocString1 = "{\"baz\": \"qux\",\"foo\": \"bar\"}";
            var originalDocString2 = "{\"baz\": \"qux\",\"foo\": \"bar\"}";

            var patchString = "[{\"op\": \"replace\",\"path\": \"/baz\",\"value\": \"boo\"}]";

            var patch = JPatchDocument.Load(patchString);


            var originalDoc1 = JToken.Parse(originalDocString1);
            var originalDoc2 = JToken.Parse(originalDocString2);


            var result1 = JPatch.Patch(originalDoc1, patch);
            var result2 = JPatch.Patch(originalDoc2, patch);
        }


        [Test]
        public void ExecutingJsonPatchFromJTokesStrings_WithoutException()
        {
            var originalDocString1 = "{\"baz\": \"qux\",\"foo\": \"bar\"}";
            var originalDocString2 = "{\"baz\": \"qux\",\"foo\": \"bar\"}";

            var patchString = "[{\"op\": \"replace\",\"path\": \"/baz\",\"value\": \"boo\"}]";

            var patch = JPatchDocument.Load(patchString);


            var originalDoc1 = JToken.Parse(originalDocString1);
            var originalDoc2 = JToken.Parse(originalDocString2);


            var success1 = JPatch.TryPatch(originalDoc1, patch, out var result1, out var patchFailReason1);
            var success2 = JPatch.TryPatch(originalDoc2, patch, out var result2, out var patchFailReason2);
        }
    }
}
