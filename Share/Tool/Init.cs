using System;
using System.Reflection;
using CommandLine;

namespace ET.Server
{
    internal static class Init
    {
        private static int Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                Log.Error(e.ExceptionObject.ToString());
            };
            
            try
            {
                // 命令行参数
                Parser.Default.ParseArguments<Options>(args)
                    .WithNotParsed(error => throw new Exception($"命令行格式错误! {error}"))
                    .WithParsed((o)=>GameRoot.Instance.AddSingleton(o));
                
                GameRoot.Instance.AddSingleton<Logger>().Log = new NLogger(Options.Instance.AppType.ToString(), Options.Instance.Process, 0);
                
                GameRoot.Instance.AddSingleton<CodeTypes, Assembly[]>(new[] { typeof (Init).Assembly });
                GameRoot.Instance.AddSingleton<EventSystem>();
                
                // 强制调用一下mongo，避免mongo库被裁剪
                MongoHelper.ToJson(1);
                
                ETTask.ExceptionHandler += Log.Error;
                
                Log.Info($"server start........................ ");
				
                switch (Options.Instance.AppType)
                {
                    case AppType.ExcelExporter:
                    {
                        Options.Instance.Console = 1;
                        ExcelExporter.Export();
                        return 0;
                    }
                    case AppType.Proto2CS:
                    {
                        Options.Instance.Console = 1;
                        Proto2CS.Export();
                        return 0;
                    }
                }
            }
            catch (Exception e)
            {
                Log.Console(e.ToString());
            }
            return 1;
        }
    }
}