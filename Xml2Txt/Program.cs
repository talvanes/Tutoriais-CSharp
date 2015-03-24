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
		// Versão do Software
		const string VERSION = "2.1";
		// Créditos
		const string CREDITS = "Copyright (C): TalbaSoft 2014. All rights reserved.";
		
		/// <summary>
		/// Exibe a ajuda do programa.
		/// </summary>
		static void Usage()
		{
			Console.WriteLine(
@"Xml2Txt(v. {0}): A utility to convert xml files into a hierarchical-based txt format. Also performs batch conversion.

Usage: 
Xml2Txt [--working-dir/-w work_dir] [--dest-dir/-d dest_dir] file1.xml file2.xml file3.xml (...)
Xml2Txt --help/-h
Xml2Txt --version/-v

where:
--working-dir/-w work_dir: working directory, where all xml files must be. By default, it is in the same directory as the executable program (exec_dir).
--dest-dir/-d dest_dir: destination directory, where all resulting '.xml.txt' files will be placed into. By default, it is also exec_dir.
file1.xml file2.xml file3.xml (...): one or more xml files that are going to be processed in the working dir. This is mandatory.
--help/-h: shows program help.
--version/-v: shows software version.", VERSION);
		}
		
		/// <summary>
		/// Exibe a versão  e créditos do programa.
		/// </summary>
		/// 
		static void Version()
		{
			Console.WriteLine("Version: {0}\n{1}", VERSION, CREDITS);
		}
		
		/// <summary>
		/// Xml2Txt: Um método interno para este programa, o qual será responsável por converter arquivos XML em TXT customizado. 
		/// </summary>
		/// <param name="caminhoArquivo">Caminho do arquivo XML a ser transformado.</param>
		static void Xml2Txt(string caminhoArquivo)
		{
			/*
			 * Criando arquivo no disco para leitura:
			 * 	um fluxo com codificação UTF-8 para suporte Unicode seguido do leitor Xml
			 */
			using (StreamReader leitor = new StreamReader(caminhoArquivo, Encoding.UTF8))
			{
				using (XmlTextReader xml = new XmlTextReader(leitor)) 
				{
					// retirando os espaços em branco do arquivo
					xml.WhitespaceHandling = WhitespaceHandling.None;
			 		
					/*
					 * Abrindo arquivo TXT para escrita, que criado a partir do XML fornecido por parâmetro
					 */
					if (!File.Exists(caminhoArquivo + ".txt")) // criar "arquivo.xml.txt" no destino se este existir
					{
						using (StreamWriter txt = new StreamWriter(caminhoArquivo + ".txt", false, Encoding.UTF8))
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
		}
		
		public static void Main(string[] args)
		{
			try {
				/*
				 * 	Considerar que o diretório de trabalho (working_dir) e o destino (dest_dir) apontarão inicialmente para o mesmo diretório 
				 *  	onde se localiza o executável,
				 * 		desde que ambos não tenham sido informados como argumentos de linha de comando.  
				 * */
				
				// criando diretório de trabalho (working_dir) e diretório destino (dest_dir)
				string working_dir, dest_dir;
				dest_dir = working_dir = Directory.GetCurrentDirectory();
				// filtro padrão para arquivos xml
				string wildcard = "*.xml";
				// flag para detectar argumentos inválidos
				bool argError = true;
				
				/*
				 * Processando todos os argumentos de linha de comando, inclusive --help, --version, --working-dir e --dest-dir
				 * */
				// um contador (local) e índice para argumento no laço *for*
				string arg;			
				for (int argCont = 0; argCont < args.Length; argCont++)
				{
					// 'arg' representará o argumento processado na linha de comando, criado para facilitar a leitura do código,  
					// e 'argCont' é um contador para argumentos.
					arg = args[argCont];
					
					if (arg == "--help" || arg == "-h") 
					{
						//
						// --help/-h, se nº arg for 1, caso contrário, sairá uma exceção
						//
						argError = false;	// argumento valido
						if (args.Length == 1) 
							// exibir uso do programa
							Usage();
						else throw new ArgumentException("Check something after '--help' context.");
					} 
					else if (arg == "--version" || arg == "-v")
					{
						//
						// --version/-v, se nº arg for 1
						//
						argError = false;	// argumento valido
						if (args.Length == 1) 
							// exibir a versão do programa
							Version();
						else throw new ArgumentException("Check something after '--version' context.");
					} else {
						//
						// --working-dir/-w (diretório de trabalho, onde estão os xml)
						//
						if (arg == "--working-dir" || arg == "-w") 
						{
							// '--working-dir' como primeiro argumento (argCont==0) é obrigatório
							// senão uma exceção ArgumentException será gerada
							if (argCont == 0)
							{
								argError = false;	// argumento valido
								
								// "pular" o contador em 2 ciclos, acessando diretamente o próximo elemento
								argCont += 1;
								// passar para o próximo argumento
								arg = args[argCont];
								// atribuir o próximo elemento a working_dir
								working_dir = arg;
							} else throw new ArgumentException("--working-dir is after --dest-dir. Run 'Xml2Txt --help' for method signature.");
						} 
						//
						// --dest-dir/-d (diretório destino)
						//
						if (arg == "--dest-dir" || arg == "-d") 
						{
							argError = false;	// argumento valido
							
							// '--dest-dir' poderá ser tanto o primeiro (argCont==0) quanto o terceiro (argCont==2) argumento
							// senão ArgumentException também será gerad
							if (argCont == 0 || argCont == 2)
							{
								// "pular" o contador em 2 ciclos, acessando diretamente o próximo elemento
								argCont += 1;
								// passar para o próximo argumento
								arg = args[argCont];
								// atribuir o próximo elemento a working_dir
								dest_dir = arg;
							} else throw new ArgumentException("--dest-dir is out of position. Run 'Xml2Txt --help' for method signature.");
						} 
						
						//
						// Lista de arquivos XML
						//
						if (arg.EndsWith(".xml")) 
						{
							argError = false;	// argumento valido
							
							// antes de tudo: definindo um filtro para o arquivo
							wildcard = arg;
							
							// localizar o diretório onde os arquivos estão
							DirectoryInfo workDir = Directory.CreateDirectory(working_dir);
							
							// listar arquivos com a extensão .xml
							FileInfo[] arquivosXml = workDir.GetFiles(wildcard);
							
							// "abrir" o diretório destino, que receberá os arquivos convertidos
							DirectoryInfo destDir = Directory.CreateDirectory(dest_dir);
							
							// processar a conversão entre formatos (XML -> TXT)
							Array.ForEach<FileInfo>(
								arquivosXml,
								arqXML => {
									// este método interno suporta apenas caminhos completos de arquivo
									Xml2Txt(arqXML.FullName);
								}
							);
							
							// mover os arquivos TXT convertidos do diretório de origem para o de destino
							FileInfo[] arquivosXmlTxt = workDir.GetFiles("*.xml.txt");
							Array.ForEach<FileInfo>(
								arquivosXmlTxt,
								arqXmlTxt => {
									File.Move(arqXmlTxt.FullName, destDir.FullName+'\\'+arqXmlTxt.Name);
								}
							);
							
						}
						
						// detectando argumento inválido
						if (argError) throw new ArgumentException(String.Format("Argument {0} does not exist.", arg));
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
			} catch (ArgumentException e) {
				// Erro de argumento, especialmente após --help e --version
				Console.WriteLine("Argument error\n{0}", e.Message);
			}
		}
	}
}