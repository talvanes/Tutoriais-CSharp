/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 05/08/2014
 * Hora: 21:06
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 * 
 * 	Adapted from Microsoft Developer Network
 * 		XmlTextReader.Read Method,
 * 		Site: http://msdn.microsoft.com/en-us/library/system.xml.xmltextreader.read%28v=vs.110%29.aspx?cs-save-lang=1&cs-lang=vb#code-snippet-1
 * 		Reading Attributes
 * 		Site: http://msdn.microsoft.com/en-US/library/by2bd43b%28v=vs.80%29.aspx
 * 		and XmlTextReader Encoding (forum post)
 * 		Site: http://forums.asp.net/t/1283805.aspx?XmlTextReader+Encoding
 * 
 */
using System;
using System.IO;
using System.Text;
using System.Xml;

namespace ReadingXML
{
	class Program
	{
		public static void Main(string[] args)
		{
			try {
				// o arquivo XML
				string arquivoXml = @"..\..\..\tomcat-users.xml";
				// criando o leitor do arquivo (em forma de fluxo, que permite codificação
				using (StreamReader leitorFluxo = new StreamReader(arquivoXml, Encoding.UTF8)) {
					// "criando" o arquivo XML, atribuindo-lhe o fluxo recém-criado
					using (XmlTextReader leitorXml = new XmlTextReader(leitorFluxo))
					{
						// retirando espaços em branco
						leitorXml.WhitespaceHandling = WhitespaceHandling.None;
						
						// rotina para ler cada nodo (tag, "etiqueta") do XML
						while (leitorXml.Read()) 
						{
							// espaços em branco
							for (int t = 0; t < leitorXml.Depth; t++) Console.Write("  ");
							
							// ler cada nodo do arquivo XML, classificando pelo tipo
							// Tipos de nodo: Elemento, Texto, CDATA, Declaração XML, Processamento de Instrução, Comentário, etc.
							switch (leitorXml.NodeType) 
							{
								// 1. Elemento: 
								// <item> => Item
							case XmlNodeType.Element:
								Console.Write("{0} ", leitorXml.Name);
								// verificar se elemento tem atributos
								if (leitorXml.HasAttributes) 
								{
									Console.Write("[ ");
									// mostrar atributos do elemento (se existirem)
									while (leitorXml.MoveToNextAttribute()) 
									{
										Console.Write(@"{0}:{1} ", leitorXml.Name, leitorXml.Value);
									}
									// voltar ao elemento
									leitorXml.MoveToElement();
																	
									Console.Write("]");
								}
								// não mostrar ":" (delimitador) se o elemento for vazio
								if (!leitorXml.IsEmptyElement) Console.WriteLine(":");
								else Console.WriteLine();
								break;
								
								// 2. Fim de elemento: 
								// </item> => /Item
							case XmlNodeType.EndElement:
								Console.WriteLine("/{0}",leitorXml.Name);
								break;
								
								// 3. Texto: conteúdo do atributo, como em: id="texto" 
								// <item id="texto">Texto</item> =>
								// Item[id:texto]: *Texto*
								// 	(Subelementos)
								// /Item
							case XmlNodeType.Text:
								Console.WriteLine("{0}", leitorXml.Value);
								break;
								
								// 4. CDATA 
								// <![CDATA[texto]]> =>
								// CDATA texto
							case XmlNodeType.CDATA:
								Console.WriteLine("CDATA {0}", leitorXml.Value);
								break;
								
								// 5. Comentário
								// <!-- comentário --> =>
								// (# comentário #)
							case XmlNodeType.Comment:
								Console.WriteLine(@"(# {0} #)", leitorXml.Value);
								break;
								
								// 6. Declaração XML 
								// <?xml version="1.0"?> =>
								// XML VERSION 1.0
							case XmlNodeType.XmlDeclaration:
								Console.WriteLine("XML VERSION 1.0");
								break;
								
								// 7. Declaração de Entidade
								// <!ENTITY nome texto> =>
								// ENTITY nome texto
							case XmlNodeType.Entity:
								Console.WriteLine("ENTITY {0} {1}", leitorXml.Name, leitorXml.Value);
								break;
								
								// 8. Referência a Entidade (caracter)
								// &entity => "entity"
							case XmlNodeType.EntityReference:
								Console.Write(@"{0}", leitorXml.Name);
								break;
								
								// 9. Documento: sem descrição
							case XmlNodeType.Document:
								break;
								
								// 10. Tipo de Documento: 
								// <!DOCTYPE nome [valor]> =>
								// DOCTYPE nome [
								// 	valor
								// ]
							case XmlNodeType.DocumentType:
								Console.WriteLine("DOCTYPE {0}\n[{1}]\n", leitorXml.Name, leitorXml.Value);
								break;
								
								// 11. Processamento de instrução
								// <? nome valor ?> =>
								// PROC nome -> valor
							case XmlNodeType.ProcessingInstruction:
								Console.WriteLine("PROC {0} -> {1}", leitorXml.Name, leitorXml.Value);
								break;
							}
						}
					}
				}
			} catch (IOException e) {
				Console.WriteLine("Cannot read file\n{0}", e.Message);
			} catch (XmlException e) {
				Console.WriteLine("XML parse error\n{0}", e.Message);
			}
			
			Console.ReadKey(true);
		}
	}
}