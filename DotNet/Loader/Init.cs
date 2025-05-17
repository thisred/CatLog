using System;
using CommandLine;

namespace ET
{
	public class Init
	{
		public void Start()
		{
			try
			{
				AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
				{
					Log.Error(e.ExceptionObject.ToString());
				};
				
				// 命令行参数
				Parser.Default.ParseArguments<Options>(System.Environment.GetCommandLineArgs())
						.WithNotParsed(error => throw new Exception($"命令行格式错误! {error}"))
						.WithParsed((o)=>GameRoot.Instance.AddSingleton(o));
				
				GameRoot.Instance.AddSingleton<Logger>().Log = new NLogger(Options.Instance.AppType.ToString(), Options.Instance.Process, 0);
				
				ETTask.ExceptionHandler += Log.Error;
				GameRoot.Instance.AddSingleton<TimeInfo>();
				GameRoot.Instance.AddSingleton<FiberManager>();

				GameRoot.Instance.AddSingleton<CodeLoader>();
			}
			catch (Exception e)
			{
				Log.Error(e);
			}
		}

		public void Update()
		{
			TimeInfo.Instance.Update();
			FiberManager.Instance.Update();
		}

		public void LateUpdate()
		{
			FiberManager.Instance.LateUpdate();
		}
	}
}
