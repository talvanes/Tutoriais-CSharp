/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 08/09/2014
 * Hora: 13:05
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;

namespace Indexadores {
	// uma classe que utilizará nossa interface
	public class ClasseIndexada<T> : IIndexador<T>
	{
		// constante que especifica o número máximo de elementos a serem criados
		public const int NUM_OF_ELEMENTS = 100;
		
		// vetor com a coleção de elementos
		private T[] dados = new T[NUM_OF_ELEMENTS];
		// propriedade Count, que retorna o número de elementos na sequência
		public int Count {
			get { return dados.Length; }
		}
		// "métodos" indexador
		public T this[int index] {
			get {
				// mostrando elementos através do indice
				T tmp;
				if (index >= 0 && index < this.Count) tmp = dados[index];
				else {
					tmp = (T) Convert.ChangeType(null, typeof(T));
				}
				return tmp;
			}
			set {
				// ajustando o elemento por meio no índice dado
				if (this.Count > 0) dados[index] = value;
				else {
					dados[index] = (T) Convert.ChangeType(null, typeof(T));
				}
			}
		}
		public int this[T element] {
			get {
				// retornar o índice com base no elemento fornecido
				int index = 0;
				while (dados[index] != element) {
					index++;
				}
				return ( index < this.Count )? index : -1;
			}
		}
	}
}