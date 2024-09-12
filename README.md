# C-Sharp-Assessment

- `dotnet run` to run application (nothing to see there)
- `dotnet test` to run unit tests


See `Program.cs` for code. 

# Assessment Details

Write a method that takes a string argument and returns whether or not characters in the string have matching brackets. Meaning for every `<` there is a corresponding `>` bracket. Return `true` if they do, return `false` if they do not.

Please unit test with the following use cases (and any others you choose to ensure functionality):
Potential Test strings and expected results:

```
<> - True
>< - False (closed bracket can’t proceed all open brackets.)
<<> - False (one bracket pair was not closed)
“” - True. (no brackets in the string will return True)
<abc...xyz> - True (non-bracket characters are ignored appropriately)
```