/**
	Baseado nos exemplos do módulo Wgetter escrito por Fernando [Vol: phoemur]
		http://www.vivaolinux.com.br/perfil/verPerfil.php?login=phoemur
	Disponível em: https://pypi.python.org/pypi/wgetter/ e https://github.com/phoemur/wgetter 

	
*/

using System;
using System.Collections;
using System.Collections.Generic;
// classe para números inteiros gigantes (BigDecimal)
using System.Numerics;
// um artifício para mostrar agrupamento de dígitos (CultureInfo pt-PT)
using System.Globalization;

namespace DefaultNamespace
{
	static class DefaultClass {
		static void Main (string[] args) {
			Dictionary<ushort, string[]> suffixes = new Dictionary<ushort, string[]>();
			suffixes.Add(1000, new string[] {"KB","MB","GB","TB","PB","EB","ZB","YB"});
			suffixes.Add(1024, new string[] {"KiB","MiB","GiB","TiB","PiB","EiB","ZiB","YiB"});
			// 1º Teste: representando os múltiplos do byte
			foreach (ushort num_system in suffixes.Keys)
			{
				Console.WriteLine("Unidades na base {0}:", num_system);
				/* "multiplicador" para o sistema adotado:
				 * base 1000 (múltiplos de 10) - usado para classificar discos rígidos
				 * base 1024 (potências de base 2) - classificar memórias semicondutivas (pendrive, unidades flash)
				*/ 
				BigInteger multiplicador = new BigInteger(num_system);
				BigInteger numSys = new BigInteger(num_system);
				CultureInfo ptPT = CultureInfo.CreateSpecificCulture("pt-PT");
				// multiplicando e representando ...
				foreach (string unid in suffixes[num_system]) 
				{
					Console.WriteLine("1 {0}: {1} B = {2} b", 
									  // nome do múltiplo digital
									  unid,	
									  // represntação em bytes (B)
									  String.Format(ptPT, "{0:00,0}", multiplicador),
									  // represntação em bits (b)
									  String.Format(ptPT, "{0:00,0}", 8 * multiplicador)
					);
					// atualizando "multiplicador" (índice) para iterar a próxima unidade
					multiplicador = BigInteger.Multiply(multiplicador, numSys);
				}
				Console.WriteLine();
			}	
		}
	}
}		