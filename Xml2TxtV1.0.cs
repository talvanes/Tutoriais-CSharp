/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 15/08/2014
 * Hora: 17:14
 * 
 * Adapted from Microsoft Developer Network
 * 		XmlTextReader.Read Method,
 * 		Site: http://msdn.microsoft.com/en-us/library/system.xml.xmltextreader.read%28v=vs.110%29.aspx?cs-save-lang=1&cs-lang=vb#code-snippet-1
 * 		Reading Attributes
 * 		Site: http://msdn.microsoft.com/en-US/library/by2bd43b%28v=vs.80%29.aspx
 * 		XmlTextReader Encoding (forum post)
 * 		Site: http://forums.asp.net/t/1283805.aspx?XmlTextReader+Encoding
 * and Tutorials Point C# Programming
 * 		StreamReader and StreamWriter
 * 		Site: http://www.tutorialspoint.com/csharp/csharp_text_files.htm
 * 
 */
using System;
using System.IO;
using System.Text;
using System.Xml;

namespace Xml2Txt
{
	class Program
	{		
		/// <summary>
		/// Xml2Txt: Um método interno para este programa, o qual será responsável por converter arquivos XML em TXT customizado (versão 1.0). Obs.: até o momento, o programa suporta apenas geração de TXT no mesmo diretório do(s) XML(s), os quais têm de ser informados explicitamente. Ainda não há texto de ajuda.
		/// </summary>
		/// <param name="nomeArquivo">Caminho do arquivo a ser processado pela função.</param>
		static void Xml2Txt(string nomeArquivo)
		{
			try {
				/*
				 * Criando arquivo no disco para leitura:
				 * 	um fluxo com codificação UTF-8 para suporte Unicode seguido do leitor Xml
				 */
				using (StreamReader leitor = new StreamReader(nomeArquivo, Encoding.UTF8))
				{
					using (XmlTextReader xml = new XmlTextReader(leitor)) 
					{
						// retirando os espaços em branco do arquivo
						xml.WhitespaceHandling = WhitespaceHandling.None;
				 		
						/*
						 * Abrindo arquivo txt para escrita, que será criado a partir do XML fornecido
						 */
						if (!File.Exists(nomeArquivo + ".txt")) // criar "arquivo.txt" se este existir
						{
							using (StreamWriter txt = new StreamWriter(nomeArquivo + ".txt", false, Encoding.UTF8))
							{
								/*
								 * Um laço (loop) para ler cada nodo (ou tag) do XML
								 */
								while (xml.Read()) 
								{
									// espaços em branco (tabulações)
									for (int tabs = 0; tabs < xml.Depth; tabs++) {
										txt.Write("\t");
									}
									
									/*
									 * Identificando os elementos XML: Element, EndElement, Text, Comment, etc. 
									 */
									switch(xml.NodeType)
									{
											/*
											 * (1) Elemento:
											 * 		<element> (...) </element> => ELEMENT: (...) /ELEMENT
											 *  	<element/> => ELEMENT
											 *  	<element key="value"> => ELEMENT[key:value]
											 * */
											case XmlNodeType.Element:
												txt.Write("{0}", xml.Name);
												// verificar se o elemento XML possui atributos
												if (xml.HasAttributes) 
												{
													txt.Write("[ ");
													
													// mostrar os atributos do elemento
													while (xml.MoveToNextAttribute()) 
													{
														txt.Write("{0}:\"{1}\" ", xml.Name, xml.Value);
													}
													// voltar ao elemento
													xml.MoveToElement();
													
													txt.Write("]");
												}
												// não mostrar delimitador dois-pontos (:) se o elemento for vazio
												if (xml.IsEmptyElement) txt.WriteLine(); 
												else txt.WriteLine(":");
												break;
											
											/*
											 * (2) Fim de elemento:
											 * 		</element> => /ELEMENT
											 * */
											case XmlNodeType.EndElement:
												txt.WriteLine("/{0}", xml.Name);
												break;
											 
											 /*
											  * (3) Texto:
											  *  	<element> text </element> => ELEMENT: text /ELEMENT
											  * */
											case XmlNodeType.Text:
												txt.WriteLine("{0}", xml.Value);
												break;
											 
											/*
											 * (4) Comentário:
											 * 		<!-- comentário --> =>	# comentário (uma cerquilha por linha)
											 * */
											case XmlNodeType.Comment:
											// forjando comentário de linha com cerquilha (#)
								            Array.ForEach<string>(
								              	// caractere de escape ('\n') para separar as linhas do texto
								              	xml.Value.Split('\n'),
								              	// dando uma tabulação e gravando no arquivo
								              	lin => txt.WriteLine("# {0}", lin)
								            ); 
											break;
											 
											/*
											 * (5) Declaração XML (primeira linha do arquivo)
											 * 	<?xml version="1.0" encoding="utf-8"?> => XML VERSION 1.0 ENCODING UTF-8
											 * */
											case XmlNodeType.XmlDeclaration:
												txt.WriteLine("XML VERSION 1.0 ENCODING UTF-8");
												break;
											 
											/*
											 * (6) Declaração CDATA:
											 * 		<![CDATA[texto]]> => CDATA texto
											 * */
											case XmlNodeType.CDATA:
												txt.WriteLine("CDATA {0}", xml.Value);
												break;
											 
											/*
											 * (7) Processamento de Instrução:
											 * 		<? nome valor ?> => PROC nome valor
											 * */
											case XmlNodeType.ProcessingInstruction:
												txt.WriteLine("PROC {0} -> {1}", xml.Name, xml.Value);
												break;
											 
											/*
											 * (8) Entidade:
											 * 		&entity => 'entity'
											 * */
											case XmlNodeType.Entity:
												txt.WriteLine("ENTITY {0} {1}", xml.Name, xml.Value);
												break;
											 
											/*
											 * (9) Declaração ENTITY:
											 * 		<!ENTITY nome texto> => ENTITY nome texto
											 * */
											case XmlNodeType.EntityReference:
												txt.Write("\'{0}\'", xml.Name);
												break;
											 
											/*
											 * (10) Documento: é a raíz do XML, e XmlTextReader não possui ação sobre ele. 
											 * */
											case XmlNodeType.Document: 
												break;
											 
											/*
											 * (11) Declaração DOCTYPE:
											 * <!DOCTYPE nome [valor]> => 
											 * 		DOCTYPE nome [
											 * 			valor
											 * 		]
											 */
											case XmlNodeType.DocumentType:
											// DOCTYPE: nome
											txt.WriteLine("DOCTYPE {0}\n[", xml.Name);
								            // DOCTYPE: valor => mostrar linha por linha 
								            Array.ForEach<string>(
								              	// caractere de escape ('\n') para separar as linhas do texto
								              	xml.Value.Split('\n'),
								              	// dando uma tabulação e gravando no arquivo
								              	lin => txt.WriteLine("\t{0}", lin)
								            );
								            txt.WriteLine("]");
										    break;
									}
									
								}
							}
						}
						
						
					}
				}
				
			} catch (IOException e) {
				// Erro de entrada e saída
				Console.WriteLine("Cannot read file\n{0}", e.Message);
			} catch (XmlException e) {
				// Não é arquivo XML ou contém caracteres malformados
				Console.WriteLine("XML parse error\n{0}", e.Message);
			} catch (UnauthorizedAccessException e) {
				// Acesso não autorizado
				Console.WriteLine("Cannot access file\n{0}", e.Message);
			}
		}
		
		public static void Main(string[] args)
		{
			/*
			 * Processando todos os argumentos de linha de comando
			 * */
			foreach (string arg in args)
			{
				// XML para TXT
				Xml2Txt(arg);
			}
		}
	}
}