// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Naming", "INTL0003:Methods PascalCase", Justification = "Underscores allowed in test names.")]
[assembly: SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Underscores allowed in test names.")]
[assembly: SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "Globalization not required in this assignment.")]
[assembly: SuppressMessage("Globalization", "CA1307:Specify StringComparison", Justification = "Globalization not required in this assignment.")]
[assembly: SuppressMessage("Style", "IDE0039:Use local function", Justification = "I don't understand the code when it wants me to format it like that :D")] 