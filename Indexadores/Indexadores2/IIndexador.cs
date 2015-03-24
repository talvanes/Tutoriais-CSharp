/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 08/09/2014
 * Hora: 12:57
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;

namespace Indexadores {
	// interface ("esqueleto") para vetores e classes com indexador
	public interface IIndexador<T> {
		// propriedade Count, que retorna o número de elementos
		int Count {
			get;
		}
		
		// "métodos" indexador
		T this[int index] {
			// retorna elemento na posição dada
			get;
			// ajusta elemento com base na posição dada
			set;
		}
		int this[T contents] {
			// retorna o índice do elemento dado
			get;
		}
	}
}