﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Editor.UnitTests.Classification;

namespace Microsoft.CodeAnalysis.Editor.CSharp.UnitTests.Classification
{
    public abstract class AbstractCSharpClassifierTests : AbstractClassifierTests
    {
        protected override async Task DefaultTestAsync(string code, string allCode, FormattedClassification[] expected)
        {
            await TestAsync(code, allCode, parseOptions: null, expected);
            await TestAsync(code, allCode, parseOptions: Options.Script, expected);
        }

        protected override string WrapInClass(string className, string code) =>
$@"class {className} {{
    {code}
}}";

        protected override string WrapInExpression(string code) =>
$@"class C {{
    void M() {{
        var q =
            {code}
    }}
}}";

        protected override string WrapInMethod(string className, string methodName, string code) =>
$@"class {className} {{
    void {methodName}() {{
        {code}
    }}
}}";

        protected override string WrapInNamespace(string code) =>
$@"namespace N {{
    {code}
}}";
    }
}
