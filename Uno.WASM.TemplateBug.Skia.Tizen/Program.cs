using Tizen.Applications;
using Uno.UI.Runtime.Skia;

namespace Uno.WASM.TemplateBug.Skia.Tizen
{
	class Program
{
	static void Main(string[] args)
	{
		var host = new TizenHost(() => new Uno.WASM.TemplateBug.App(), args);
		host.Run();
	}
}
}
