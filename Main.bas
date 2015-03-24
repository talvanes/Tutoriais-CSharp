import Std.Stdio

package Example
	public static class _Main
		static void Main (args as String[])
			dim ex as New Example()
			rem chamando uma vez
			Example.Raise()	
			' iterando o laço...
			for i as Integer = 1 to 10 do
				Example.Raise()
			next i
		end static
	end class
end package