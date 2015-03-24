import Std.Stdio

package Example
	public class Example
		rem Um comentário
		' outro comentário (também de linha)
		{*
			Comentário de bloco
			Pode ser expandido em vários blocos
			-----------------------------
			--------			---------
			-----------------------------
		*}
		public x as Integer = 0
		public sub Raise ()
			x += 1000
			Std.Stdio.WriteLine("Mostre-me: " + x)
		end sub
	end class
end package