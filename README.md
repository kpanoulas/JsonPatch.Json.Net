# JsonPatch.Json.Net
This implementation of JsonPatch is targeted towards projects that use Newtonsoft's Json.Net library and would like to manipulate Json documents based on JToken / JObject.

The reason for creating this library is to achieve performance optimizations in the following cases:
- When json documents are parsed and converted to JTokens for other reasons (e.g. schema validation, or manipulation) and a JsonPatch would need to be applied to them.
- When a single JsonPatch would need to be applied to multiple documents, and deserializing the same JsonPatch document multiple times would be inefficient. 

# Usage examples

## Executing JsonPatch using json strings

### Using exceptions

```
var originalDocString = "{\"baz\": \"qux\",\"foo\": \"bar\"}";
var patchString = "[{\"op\": \"replace\",\"path\": \"/baz\",\"value\": \"boo\"}]";
var result = JPatch.Patch(originalDocString, patchString);
```

### Returning errors inside a JPatchFailReason class.

```
var originalDocString = "{\"baz\": \"qux\",\"foo\": \"bar\"}";
var patchString = "[{\"op\": \"replace\",\"path\": \"/baz\",\"value\": \"boo\"}]";
var success = JPatch.TryPatch(originalDocString, patchString, out var resultString, out var patchFailReason);
```

## Executing JsonPatch using JToken objects
This method of execution is the reason why JsonPatch.Json.Net was developed.

### Using exceptions
```
var originalDocString1 = "{\"baz\": \"qux\",\"foo\": \"bar\"}";
var originalDocString2 = "{\"baz\": \"qux\",\"foo\": \"bar\"}";
var patchString = "[{\"op\": \"replace\",\"path\": \"/baz\",\"value\": \"boo\"}]";

var patch = JPatchDocument.Load(patchString);
var originalDoc1 = JToken.Parse(originalDocString1);
var originalDoc2 = JToken.Parse(originalDocString2);

var result1 = JPatch.Patch(originalDoc1, patch);
var result2 = JPatch.Patch(originalDoc2, patch);
```

### Returning errors inside a JPatchFailReason class.
With this method, the patch document is only parsed once, and the patched documents are still in JToken form, ready for
further processing, without needing another parsing.

This method of execution returns errors inside a JPatchFailReason class.
```
var originalDocString1 = "{\"baz\": \"qux\",\"foo\": \"bar\"}";
var originalDocString2 = "{\"baz\": \"qux\",\"foo\": \"bar\"}";

var patchString = "[{\"op\": \"replace\",\"path\": \"/baz\",\"value\": \"boo\"}]";
var patch = JPatchDocument.Load(patchString);

var originalDoc1 = JToken.Parse(originalDocString1);
var originalDoc2 = JToken.Parse(originalDocString2);

var success1 = JPatch.TryPatch(originalDoc1, patch, out var result1, out var patchFailReason1);
var success2 = JPatch.TryPatch(originalDoc2, patch, out var result2, out var patchFailReason2);
```

