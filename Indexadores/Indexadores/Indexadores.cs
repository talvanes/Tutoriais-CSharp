/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 07/09/2014
 * Hora: 13:35
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
namespace Indexadores {
	// classe IndexedArray
	public class IndexedArray {
			// propriedade Count: ajusta e retorna o número de elementos existentes
			static private int size = 6;
			public int Count {
				// get: retorna a quantidade de elementos na sequência
				get { return size; }
				// set: ajustar somente se value >= 1 
				set {
					switch (value) 
					{
						case 0: 
							size = 1; 
							break;
						default: 
							size = value; 
							break;
					}
				}
			}
			
			// indexedList: vetor que contém os elementos da lista
			private object[] indexedArray = new object[size];
			
			/* construtor */
			public IndexedArray(int count = 6) {
				size = count;
				for (int i = 0; i < size; i++) {
					indexedArray[i] = null;
				}
			}
				
				/* Indexers (indexadores) */
			public object this[int index] {
				get {
					// retornar o elemento apontado pelo índice
					return (index >= 0 && index < this.Count)? indexedArray[index] : null;
				}
				set {
					// ajustar elemento na posição definida pelo indice
					if (index >= 0 && index < this.Count) indexedArray[index] = value;
				}
			}
			public int this[object contents]	{
				get {
					// retornar o índice onde se localiza o elemento dado
					int index = 0;
					while (indexedArray[index] != contents) 
					{
						index++;
					}
					return index;
				}
			}
		}
}
