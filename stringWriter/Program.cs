using static System.Console;


string textReaderText = "TexrReader é a classe base abstrata " +
                        "de StreamReader e StringReader, que lê caracteres " +
                        "de streams e string, respectivamente. \n\n" +

                        "Crie uma instância TextReader para abrir um arquivo de texto " +
                        "para ler um intervalo especificado de caracteres " +
                        "ou para criar um leitor baseado em um fluxo existente. \n\n" +

                        "Você também pode usar uma instância de TextReader para ler " +
                        "texto de um armazenamento de suporte personalizado usando as mesmas " +
                        "APIs que usaria para uma string ou um fluxo. \n\n";


WriteLine($"Texto original: {textReaderText}"); //Visualizar o texto original

string linha, paragrafo = null; //Criamos duas variáveis inicializadas como nulas
var sr = new StringReader(textReaderText); //Fazemos a leitura de todo o texto


while (true) //Criamos um loop para leitura.
{
    linha = sr.ReadLine();

    if(linha != null) //Sera executado o comando abaixo se não for nulo
    {
        paragrafo = paragrafo + linha + " "; //Colocamos todas as linhas em parágrafos
    }
    else //Se a linha for nula, o comando abaixo será executado
    {
        paragrafo += "\n";
        break;
    }
}


WriteLine($"Texto modificado: {paragrafo}");


int caractereLido;
char caractereConvertido;


var sw = new StringWriter(); 
sr = new StringReader(paragrafo); //É feita a abertura de um novo leitor após a modificação feita no texto.


while (true)
{
    caractereLido = sr.Read(); //Retorna 1 decimal da tabela asc
    if (caractereLido == -1) break; 
                                //Se for = a menos 1 não faz parte da tabela asc
                                //faz com que o loop infinito do while seja encerrado
                                //Como é informado apenas um comando simples, não é necessário abertura de chaves

    caractereConvertido = Convert.ToChar(caractereLido); //Convert.ToChar(caractereLido) interpreta o numero decimal e o converte em um caractere da tabela asc(alfa-numerico)
    if(caractereConvertido == '.')
    {
        sw.Write("\n\n");

        sr.Read();
        sr.Read();
    }
    else
    {
        sw.Write(caractereConvertido);
    }
}

 WriteLine($"Texto armazenado no StringWriter: {sw.ToString()}");

 WriteLine("\n \n Digite [ENTER] para finalizar.");
 ReadLine();