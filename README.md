# JsonPatch.Json.Net
This implementation of JsonPath is targeted towards projects that use Newtonsoft's Json.Net library and would like to manipulate Json documents based on JToken / JObject.

The reason for creating this library is to achieve performance optimizations in the following cases:


- When json documents are parsed and converted to JTokens for other reasons (e.g. schema validation, or manipulation) and a JsonPatch would need to be applied to them.
- When a single JsonPatch would need to be applied to multiple documents, and deserializing the same JsonPatch document multiple times would be inefficient. 

# Usage examples

## Executing JsonPatch using json strings
This method of execution throws exceptions of type JPatchException

```
var originalDocString = "{\"baz\": \"qux\",\"foo\": \"bar\"}";
var patchString = "[{\"op\": \"replace\",\"path\": \"/baz\",\"value\": \"boo\"}]";
var result = JPatch.Patch(originalDocString, patchString);
```

This method of execution returns errors inside a JPatchFailReason class.

```
var originalDocString = "{\"baz\": \"qux\",\"foo\": \"bar\"}";
var patchString = "[{\"op\": \"replace\",\"path\": \"/baz\",\"value\": \"boo\"}]";
var success = JPatch.TryPatch(originalDocString, patchString, out var resultString, out var patchFailReason);
```

## Executing JsonPatch using JToken objects
This method of execution is the reason why JsonPatch.Json.Net was developed.




