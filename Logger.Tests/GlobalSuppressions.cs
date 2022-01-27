// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.
using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Naming", "INTL0003:Methods PascalCase", Justification = "Tests can use underscores in our project")]
[assembly: SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Tests can use underscores in our project")]
[assembly: SuppressMessage("Design", "CA1014:Mark assemblies with CLSCompliant", Justification = "Assembly compliance not required in project")]
[assembly: SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "Globalization not needed in this assignment")]
