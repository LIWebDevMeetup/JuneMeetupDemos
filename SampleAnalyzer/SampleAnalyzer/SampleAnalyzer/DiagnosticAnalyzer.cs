using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace SampleAnalyzer
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class SampleAnalyzerAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "SampleAnalyzer";

        // You can change these strings in the Resources.resx file. If you do not want your analyzer to be localize-able, you can use regular strings for Title and MessageFormat.
        internal static readonly LocalizableString Title = new LocalizableResourceString(nameof(Resources.AnalyzerTitle), Resources.ResourceManager, typeof(Resources));
        internal static readonly LocalizableString MessageFormat = new LocalizableResourceString(nameof(Resources.AnalyzerMessageFormat), Resources.ResourceManager, typeof(Resources));
        internal static readonly LocalizableString Description = new LocalizableResourceString(nameof(Resources.AnalyzerDescription), Resources.ResourceManager, typeof(Resources));
        internal const string Category = "LI Web Dev Meetup";

        internal static DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Error, isEnabledByDefault: true, description: Description);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }

        public override void Initialize(AnalysisContext context)
        {
            // TODO: Consider registering other actions that act on syntax instead of or in addition to symbols
            //context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.NamedType);

            context.RegisterSyntaxNodeAction(r => AnalyzeObjectCreation(r), SyntaxKind.ObjectCreationExpression);
        }

        private void AnalyzeObjectCreation(SyntaxNodeAnalysisContext ctx)
        {
            var oce = (ObjectCreationExpressionSyntax)ctx.Node;
            var target = ctx.SemanticModel.Compilation.GetTypeByMetadataName("AnalyzerDemo.MyRepo");
            var cn_target = ctx.SemanticModel.Compilation.GetTypeByMetadataName("System.Data.OleDb.OleDbConnection");

            var repoType = ctx.SemanticModel.GetSymbolInfo(oce.Type).Symbol as INamedTypeSymbol;

            var count = oce.ArgumentList.Arguments.Count;
            
            if (repoType.ConstructedFrom.Equals(target) && count > 0)
            {
                ctx.ReportDiagnostic(Diagnostic.Create(Rule, oce.Type.GetLocation()));
            }
        }
    }
}
