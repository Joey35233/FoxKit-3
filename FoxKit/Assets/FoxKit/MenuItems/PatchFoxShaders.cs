using Fox.Core.Utils;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace FoxKit.MenuItems
{
    public static class PatchFoxShaders
    {
        private const string ShaderDirectory = "Assets/TEST/ASSETS/SHADERS";

        private const string PreInclude = "#include \"../UnityPatch/PreEntryPoint.hlsl\"";
        private const string PostInclude = "#include \"../UnityPatch/PostEntryPoint.hlsl\"";

        private const string PreSentinel = "PreEntryPoint.hlsl";
        private const string PostSentinel = "PostEntryPoint.hlsl";

        [MenuItem("FoxKit/Patch Fox Shaders")]
        public static void PatchShaders()
        {
            TaskLogger logger = new("Patch Fox Shaders");
            string absoluteDirectory = Path.GetFullPath(Path.Combine(Application.dataPath, "..", ShaderDirectory));

            if (!Directory.Exists(absoluteDirectory))
            {
                logger.AddError($"[PatchFoxShaders] Shader directory not found: {absoluteDirectory}");
                logger.LogToUnityConsole();
                return;
            }

            string[] hlslFiles = Directory.GetFiles(absoluteDirectory, "*.hlsl", SearchOption.AllDirectories);

            int patched = 0;
            int alreadyDone = 0;
            int errors = 0;
            foreach (string filePath in hlslFiles)
            {
                string mainFunctionName = null;
                if (filePath.Contains("_ps.hlsl"))
                {
                    mainFunctionName = "ps_main";
                }
                else if (filePath.Contains("_vs.hlsl"))
                {
                    mainFunctionName = "vs_main";
                }
                else
                {
                    logger.AddError($"Unrecognized shader type: {filePath}");
                }

                PatchResult result = PatchFile(filePath, mainFunctionName, logger);

                switch (result)
                {
                    case PatchResult.Patched: patched++; break;
                    case PatchResult.AlreadyPatched: alreadyDone++; break;
                    case PatchResult.Error: errors++; break;
                }
            }

            AssetDatabase.Refresh();

            logger.AddMessage($"Patched: {patched}, Skipped: {alreadyDone}, Errors: {errors}");
            logger.LogToUnityConsole();
        }

        private enum PatchResult { Patched, AlreadyPatched, Error }

        private static PatchResult PatchFile(string filePath, string mainFunctionName, TaskLogger logger)
        {
            string source;
            try
            {
                source = File.ReadAllText(filePath, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                logger.AddError($"Could not read '{filePath}': {ex.Message}");
                return PatchResult.Error;
            }

            // Check if already patched
            if (source.Contains(PreSentinel) || source.Contains(PostSentinel))
            {
                return PatchResult.AlreadyPatched;
            }

            source = PatchRegisterMap(source);
            source = PatchToVPos(source);
            source = PatchTFetch(source);

            // Locate ps_main or vs_main
            // Match the opening brace of ps_main or vs_main
            // Look for the first { that follows a line containing "ps_main" / "vs_main"
            Match funcMatch = Regex.Match(
                source,
                mainFunctionName + @"\s*\([^)]*\)\s*\{",
                RegexOptions.Singleline);

            if (!funcMatch.Success)
            {
                logger.AddError($"No {mainFunctionName} in '{filePath}'.");
                return PatchResult.Error;
            }

            // Index of the character immediately after the opening {
            int openBraceIndex = funcMatch.Index + funcMatch.Length - 1; // points at '{'
            int afterOpen = openBraceIndex + 1;

            // Find matching closing brace
            int closeBraceIndex = FindMatchingBrace(source, openBraceIndex);

            if (closeBraceIndex < 0)
            {
                logger.AddError($"Could not find closing brace of {mainFunctionName} in '{filePath}'.");
                return PatchResult.Error;
            }

            // Detect indentation used inside the function
            // Peek at the first non-empty line inside the body to grab leading whitespace
            string bodyIndent = DetectBodyIndent(source, afterOpen, closeBraceIndex);

            // Build the patched source
            //
            //   ...ps_main(...) {
            //       #include "../UnityPatch/PreEntryPoint.hlsl"   inserted after '{'
            //       <original body>
            //       #include "../UnityPatch/PostEntryPoint.hlsl"  inserted before '}'
            //   }
            //
            StringBuilder sb = new(source.Length + 256);

            // Everything up to and including {
            sb.Append(source, 0, afterOpen);

            // Pre-include on its own line right after {
            sb.AppendLine();
            sb.Append(bodyIndent);
            sb.AppendLine(PreInclude);

            // Original body (between { and })
            string originalBody = source[afterOpen..closeBraceIndex];

            // Strip a leading newline that we already emitted so we don't double-blank
            if (originalBody.StartsWith("\r\n"))
                originalBody = originalBody.Substring(2);
            else if (originalBody.StartsWith("\n"))
                originalBody = originalBody.Substring(1);

            // Strip trailing whitespace/newlines from the body so we can control spacing
            originalBody = originalBody.TrimEnd();

            sb.Append(originalBody);

            // Post-include on its own line just before }
            sb.AppendLine();
            sb.Append(bodyIndent);
            sb.AppendLine(PostInclude);

            // Everything from (and including) }
            sb.Append(source, closeBraceIndex, source.Length - closeBraceIndex);

            // Write back
            try
            {
                File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
            }
            catch (Exception ex)
            {
                logger.AddError($"Couldn't write '{filePath}': {ex.Message}");
                return PatchResult.Error;
            }

            return PatchResult.Patched;
        }

        private static string PatchRegisterMap(string source)
        {
            return PatchString(source, $"#\tdefine REGISTERMAP(_type, _name, _register) cbuffer c##_type : _register {{ _type _name; }}",
                $"#\tdefine REGISTERMAP(_type, _name, _register) cbuffer c##_type {{ static _type _name; }}");
        }

        private static string PatchToVPos(string source)
        {
            return PatchString(source, $"#define ToVPos(vpos) (vpos + PIXELCENTEROFFSET)\r\n#define ToVPos4 ToVPos",
                $"#define ToVPos(wpos) (float2(wpos.x, g_psSystem.m_renderBuffer.y - wpos.y) + PIXELCENTEROFFSET)\r\n#define ToVPos4(wpos) float4(ToVPos(wpos), 0, 0 )");
        }

        private static string PatchTFetch(string source)
        {
            return PatchString(source, $"#define TFetch(_texture, _sampler, _uv) \t\t_texture.Sample(_sampler, _uv)\r\n#define TFetchOffset(_texture, _sampler, _uv, _offset) \t\t_texture.Sample(_sampler, _uv, _offset)\r\n\r\n#define TFetch1D \t\t\t\t\t\t\t\tTFetch\r\n#define TFetch1DOffset\t\t\t\t\t\t\tTFetchOffset\r\n#define TFetch2D \t\t\t\t\t\t\t\tTFetch\r\n#define TFetch2DOffset\t\t\t\t\t\t\tTFetchOffset\r\n#define TFetch2DGrad\t\t\t\t\t\t\tTFetchGrad\r\n#define TFetch2DProj(_texture, _sampler, _uv) \tTFetch(_texture, _sampler, CalcProjectCoords(_uv))\r\n\r\n#define TFetch3D \t\t\t\t\t\t\t\tTFetch\r\n#define TFetchCube \t\t\t\t\t\t\t\tTFetch\r\n#define TFetchCubeBias(_texture, _sampler, _uv) _texture.SampleBias(_sampler, (_uv).xyz, (_uv).w)\r\n\r\n\r\n#line 326 \"..\\Gr\\Dg\\shader\\shader.h\"\r\n#define TFetchGrad(_texture, _sampler, _uv, _dx, _dy) _texture.SampleGrad(_sampler, _uv, _dx, _dy)\r\n#define TFetch2DLod(_texture, _sampler, _uv) \t_texture.SampleLevel(_sampler, (_uv).xy, (_uv).w)\r\n#define TFetchCubeLod(_texture, _sampler, _uv)\t_texture.SampleLevel(_sampler, (_uv).xyz, (_uv).w)\r\n\r\n#line 331 \"..\\Gr\\Dg\\shader\\shader.h\"\r\n\r\nfloat TFetch2DProjCmp(Texture2D _texture, SamplerComparisonState _sampler, float4 _uv){{\r\n\tfloat3 prjectionUV = (_uv.xyz/_uv.w );\r\n\treturn _texture.SampleCmp(_sampler, prjectionUV.xy, prjectionUV.z);\r\n}}",
                $"#define TFetch(_texture, _sampler, _uv)         _texture.Sample(_sampler, float2((_uv).x, 1 - (_uv).y))\r\n#define TFetchOffset(_texture, _sampler, _uv, _offset) _texture.Sample(_sampler, float2((_uv).x, 1 - (_uv).y), _offset)\r\n\r\n#define TFetch1D(_texture, _sampler, _uv)         _texture.Sample(_sampler, (_uv))\r\n#define TFetch1DOffset(_texture, _sampler, _uv, _offset) _texture.Sample(_sampler, (_uv), _offset)\r\n#define TFetch2D                                 TFetch\r\n#define TFetch2DOffset                            TFetchOffset\r\n#define TFetch2DGrad                            TFetchGrad\r\n#define TFetch2DProj(_texture, _sampler, _uv)     TFetch(_texture, _sampler, CalcProjectCoords(_uv))\r\n\r\n#define TFetch3D(_texture, _sampler, _uv)        _texture.Sample(_sampler, float3((_uv).x, 1 - (_uv).y, (_uv).z))\r\n#define TFetchCube(_texture, _sampler, _uv)        _texture.Sample(_sampler, float3((_uv).x, 1 - (_uv).y, (_uv).z))\r\n#define TFetchCubeBias(_texture, _sampler, _uv)    _texture.SampleBias(_sampler, float3((_uv).x, 1 - (_uv).y, (_uv).z), (_uv).w)\r\n\r\n\r\n#line 326 \"..\\Gr\\Dg\\shader\\shader.h\"\r\n#define TFetchGrad(_texture, _sampler, _uv, _dx, _dy) _texture.SampleGrad(_sampler, float2((_uv).x, 1 - (_uv).y), _dx, _dy) // Narrows support to 2D only but only used for terrain albedo and normal textures so this should be okay.\r\n#define TFetch2DLod(_texture, _sampler, _uv)     _texture.SampleLevel(_sampler, float2((_uv).x, 1 - (_uv).y), (_uv).w)\r\n#define TFetchCubeLod(_texture, _sampler, _uv)    _texture.SampleLevel(_sampler, float3((_uv).x, 1 - (_uv).y, (_uv).z).xyz, (_uv).w)\r\n\r\n#line 331 \"..\\Gr\\Dg\\shader\\shader.h\"\r\n\r\nfloat TFetch2DProjCmp(Texture2D _texture, SamplerComparisonState _sampler, float4 _uv)\r\n{{\r\n    float3 prjectionUV = (_uv.xyz/_uv.w );\r\n    return _texture.SampleCmp(_sampler, float2(prjectionUV.x, 1 - prjectionUV.y), prjectionUV.z);\r\n}}");
        }


        private static string PatchString(string source, string pattern, string replacement)
        {
            return source.Replace(pattern, replacement);
        }

        /// <summary>
        /// Walk the source from the position of the opening brace and return the index of its matching closing brace, respecting nesting and strings.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="openIndex"></param>
        /// <returns></returns>
        private static int FindMatchingBrace(string source, int openIndex)
        {
            int depth = 0;
            bool inLine = false; // inside // comment
            bool inBlock = false; // inside /* */ comment
            bool inStr = false; // inside "string"

            for (int i = openIndex; i < source.Length; i++)
            {
                char c = source[i];

                // Handle line endings
                if (c == '\n')
                {
                    inLine = false;
                    continue;
                }

                if (inLine) continue;

                // Block comment end
                if (inBlock)
                {
                    if (c == '*' && i + 1 < source.Length && source[i + 1] == '/')
                    {
                        inBlock = false;
                        i++;
                    }
                    continue;
                }

                // String literal
                if (inStr)
                {
                    if (c == '\\') { i++; continue; } // escape
                    if (c == '"') { inStr = false; }
                    continue;
                }

                // Detect comment / string start
                if (c == '/' && i + 1 < source.Length)
                {
                    if (source[i + 1] == '/') { inLine = true; i++; continue; }
                    if (source[i + 1] == '*') { inBlock = true; i++; continue; }
                }

                if (c == '"') { inStr = true; continue; }

                // Brace tracking
                if (c == '{') { depth++; continue; }
                if (c == '}')
                {
                    depth--;
                    if (depth == 0) return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Return the leading whitespace of the first non-empty line inside the body. Falls back to a single tab if nothing is found.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="bodyStart"></param>
        /// <param name="bodyEnd"></param>
        /// <returns></returns>
        private static string DetectBodyIndent(string source, int bodyStart, int bodyEnd)
        {
            int i = bodyStart;

            // Skip the immediate newline after {
            if (i < bodyEnd && source[i] == '\r') i++;
            if (i < bodyEnd && source[i] == '\n') i++;

            // Collect leading whitespace characters
            int wsStart = i;
            while (i < bodyEnd && (source[i] == ' ' || source[i] == '\t'))
                i++;

            return i > wsStart ? source[wsStart..i] : "\t";
        }
    }
}